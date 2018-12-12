using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SopromatLib
{
    public class BaseCircleSector : BaseShape
    {
        private float Radius, AngleRadian;
        private int AngleDegree;
        private float HalfAngle;
        private float radius_2, radius_4;
        /// <summary>
        /// Круговой сектор, симметрично относительно вертикальной оси, угол раскрытия 2 альфа
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="angleDegree"></param>
        public BaseCircleSector(float radius, int angleDegree) : base($"Сектор радиус: {radius}, угол раскрытия: {angleDegree}")
        {
            Radius = radius;
            AngleDegree = angleDegree;
            AngleRadian = (float)(angleDegree * Math.PI / 180);
            HalfAngle = AngleRadian / 2;
            radius_2 = radius * radius;
            radius_4 = radius_2 * radius_2;
        }

        public override float Area => HalfAngle * Radius * Radius;

        public override PointF CenterPoint => new PointF(0, 2 * Radius * (float)Math.Sin(HalfAngle) / (3 * HalfAngle));

        public override PointF AxeMoment()
        {
            var J = radius_4 / 8;
            var k1 = AngleRadian;
            var k2 = Math.Sin(AngleRadian);
            var k3 = Math.Pow(Math.Sin(HalfAngle), 2);
            var pc = CenterPoint;
            return new PointF(
                (float)(J * (k1 + k2 - 64f / 9f * k3 / AngleRadian)),
                (float)(J * (k1 - k2))
                );
        }

        public override float CenterMoment()
        {
            return 0;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawPie(pen, new RectangleF(-Radius, -Radius, 2 * Radius, 2 * Radius),
                                (float)(90 - HalfAngle * 180 / Math.PI),
                                (float)(AngleRadian * 180 / Math.PI));
        }

        public override List<PointF> GetCorners(float rotate = 0)
        {
            var xc = (float)(Radius * Math.Sin(HalfAngle));
            var yc = (float)(Radius * Math.Cos(HalfAngle));

            List<PointF> result = new List<PointF> { new PointF(0, 0), new PointF(xc, yc), new PointF(-xc, yc) };

            var min = (float)(Math.PI / 2 - HalfAngle) + (rotate % (float)(Math.PI * 2));
            var koefs = new[] { 0, 1, 0, -1, 0 };
            for (int i = 0; i < 4; i++)
            {
                var a = (float)(i * Math.PI / 2);
                if (IsBetween(a, min, min + AngleRadian))
                    result.Add(new PointF(Radius * koefs[i + 1], Radius * koefs[i]));
            }
            return result.Distinct().ToList();
        }

        private bool IsBetween(float v, float min, float max)
        {
            return (v >= min) && (v <= max);
        }
        public override string ToString()
        {
            return $"CS {Radius} {AngleDegree}";
        }
    }
}
