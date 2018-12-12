using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SopromatLib
{
    public class ConcreteShape : IConcreteShape
    {
        private IBaseShape baseShape;
        private ConcreteParameters parameters;

        public ConcreteShape(IBaseShape baseShape, ConcreteParameters parameters)
        {
            this.baseShape = baseShape;
            this.parameters = parameters;
        }

        public PointF CenterPoint => baseShape.CenterPoint.Rotate(parameters.AngleRadian).Move(parameters.Location);

        public PointF AxeMoment() => baseShape.AxeMoment();
        public PointF AxeMoment(PointF point)
        {
            var J = baseShape.AxeMoment();
            J.X *= parameters.Koef;
            J.Y *= parameters.Koef;
            var J1 = (J.X + J.Y) / 2;
            var J2 = (float)((J.X - J.Y) / 2 * Math.Cos(-2 * parameters.AngleRadian));
            var J3 = (float)(baseShape.CenterMoment() * Math.Sin(-2 * parameters.AngleRadian));
            var Jc = new PointF(J1 + J2 - J3, J1 - J2 + J3);
            return new PointF(
                Jc.X + Area * (float)Math.Pow(CenterPoint.Y - point.Y, 2),
                Jc.Y + Area * (float)Math.Pow(CenterPoint.X - point.X, 2));
        }

        public float Area => baseShape.Area * parameters.Koef;

        public float CenterMoment()
        {
            return baseShape.CenterMoment();
        }
        public float CenterMoment(PointF point)
        {
            var bmAxe = baseShape.AxeMoment();
            var bmCenter = baseShape.CenterMoment();
            return (float)((bmAxe.X - bmAxe.Y) / 2 * Math.Sin(-2 * parameters.AngleRadian) +
                bmCenter * Math.Cos(-2 * parameters.AngleRadian) +
                Area * (CenterPoint.X - point.X) * (CenterPoint.Y - point.Y));
        }


        public void Draw(Graphics g, Pen p)
        {
            throw new NotImplementedException();
        }

        public List<PointF> GetCorners(float rotate = 0)
        {
            return baseShape.GetCorners(parameters.AngleRadian).Rotate(parameters.AngleRadian).Move(parameters.Location).Distinct().ToList();
        }

        public string GetDetails()
        {
            StringBuilder s = new StringBuilder();
            //s.AppendLine("КОНКРЕТНАЯ ФИГУРА ОТНОСИТЕЛЬНО ЦМ\n" + new string('-', 50));
            s.AppendLine(baseShape.GetDetails());
            s.AppendLine(parameters.GetDetails());
            s.AppendLine($"CenterPoint: {CenterPoint.ToString()}");
            //s.AppendLine($"Приведенная площадь: {Area}");
            return s.ToString();
        }

        public string GetDetails(PointF point)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine(GetDetails());
            s.AppendLine("КОНКРЕТНАЯ ФИГУРА ОТНОСИТЕЛЬНО ТОЧКИ " + point.ToString());
            s.AppendLine($" Моменты относительно точки {point.ToString()}");
            s.AppendLine($"  осевой: {AxeMoment(point):0.000}");
            s.AppendLine($"  центробежный: {CenterMoment(point):0.000}");
            s.AppendLine("Координаты углов:");
            s.AppendLine(string.Join(", ", GetCorners(parameters.AngleRadian)));
            s.AppendLine($"Максимальные расстояния: {get}")
            return s.ToString();
        }

        public override string ToString()
        {
            return baseShape.ToString() + " " + parameters.ToString();
        }

    }
}
