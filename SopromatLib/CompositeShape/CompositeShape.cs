using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SopromatLib
{
    public class CompositeShape : IConcreteShape
    {
        private struct ShapeDetails
        {
            internal int Id;
            internal int koef;
            internal IConcreteShape shape;
        }

        private List<ShapeDetails> shapes;

        public CompositeShape()
        {
            shapes = new List<ShapeDetails>();
        }

        public void Add(IConcreteShape shape)
        {
            shapes.Add(new ShapeDetails { koef = 1, shape = shape });
        }
        public void Substract(IConcreteShape shape)
        {
            shapes.Add(new ShapeDetails { koef = -1, shape = shape });
        }

        public float Area => shapes.Sum(s => s.shape.Area * s.koef);

        public PointF CenterPoint
        {
            get
            {
                float sumXc = 0;
                float sumYc = 0;
                float sumS = Area;
                foreach (var v in shapes)
                {
                    var pc = v.shape.CenterPoint;
                    sumXc += v.koef * v.shape.Area * pc.X;
                    sumYc += v.koef * v.shape.Area * pc.Y;
                }
                var x = sumXc / sumS;
                var y = sumYc / sumS;
                return new PointF(x, y);
            }
        }

        public PointF AxeMoment(PointF point)
        {
            float Angle = 0;
            var J = AxeMoment();
            float J1 = (J.X + J.Y) / 2;
            float J2 = (float)((J.X - J.Y) / 2 * Math.Cos(-2 * Angle));
            float J3 = (float)(CenterMoment() * Math.Sin(-2 * Angle));
            var Jc = new PointF(J1 + J2 - J3, J1 - J2 + J3);
            return new PointF(
                Jc.X + Area * (float)Math.Pow(CenterPoint.Y - point.Y, 2),
                Jc.Y + Area * (float)Math.Pow(CenterPoint.X - point.X, 2)
                );
        }

        public PointF AxeMoment()
        {
            var sumJ = new PointF(0, 0);
            var pc = CenterPoint;
            foreach (var v in shapes)
            {
                var mcm = v.shape.AxeMoment(pc);
                sumJ.X += v.koef * mcm.X;
                sumJ.Y += v.koef * mcm.Y;
            }
            return sumJ;
        }

        public float CenterMoment(PointF point)
        {
            float Angle = 0;
            var bmAxe = AxeMoment();
            var bmCenter = CenterMoment();
            var result = (bmAxe.X - bmAxe.Y) / 2 * Math.Sin(-2 * Angle) +
                            bmCenter * Math.Cos(-2 * Angle) +
                            Area * (CenterPoint.X - point.X) * (CenterPoint.Y - point.Y);
            return (float)result;
        }

        public float CenterMoment()
        {
            float Jxy = 0;
            var pc = CenterPoint;
            foreach (var v in shapes)
                Jxy += v.koef * v.shape.CenterMoment(pc);
            return Jxy;
        }

        public void Draw(Graphics g, Brush brush)
        {
            foreach (var shapeDetails in shapes)
            {
                shapeDetails.shape.Draw(g, shapeDetails.koef > 0 ? Brushes.Black : Brushes.White);
            }
            g.TranslateTransform(CenterPoint.X, CenterPoint.Y);
            g.DrawLine(Pens.Red, -10, 0, 10, 0);
            g.DrawLine(Pens.Red, 0, -10, 0, 10);
            g.TranslateTransform(-CenterPoint.X, -CenterPoint.Y);
        }

        public List<PointF> GetCorners(float rotate = 0)
        {
            List<PointF> corners = new List<PointF>();
            foreach (var v in shapes)
            {
                corners.AddRange(v.shape.GetCorners());
            }
            return corners.Distinct().ToList();
        }

        public string GetDetails(PointF point)
        {
            StringBuilder s = new StringBuilder();
            //foreach (var v in shapes)
            //    s.AppendLine(v.shape.GetDetails(point));
            s.AppendLine("СОСТАВНАЯ ФИГУРА" + Environment.NewLine + new string('-', 50));
            s.AppendLine($"CenterPoint: {CenterPoint.ToString()}");
            s.AppendLine($"Приведенная площадь: {Area}");
            //s.AppendLine("Координаты углов:");
            //s.AppendLine(string.Join(", ", GetCorners()));
            s.AppendLine($" Моменты относительно точки {point.ToString()}");
            s.AppendLine($"  осевой: {AxeMoment(point):0.000}");
            s.AppendLine($"  центробежный: {CenterMoment(point):0.000}");
            s.AppendLine("Максимальные расстояния: " + GetMaxDistance(point).ToString());
            return s.ToString();
        }

        public string GetDetails()
        {
            return GetDetails(new PointF(0, 0));
        }

        public PointF GetMaxDistance(PointF point)
        {
            var corners = GetCorners().Select(c => new PointF(c.X - point.X, c.Y - point.Y));
            return new PointF(
                corners.Max(c => Math.Abs(c.X)),
                corners.Max(c => Math.Abs(c.Y))
                );

        }

        public override string ToString()
        {
            return string.Join("\n", shapes.Select(s => s.shape.ToString()).ToArray());
        }
    }
}
