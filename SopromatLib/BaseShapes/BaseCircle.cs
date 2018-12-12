using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SopromatLib
{
    public class BaseCircle : BaseShape
    {
        private float Radius, Angle;
        private int AngleDegree;

        public BaseCircle(float radius, int angleDegree = 0) : base("Круг радиусом " + radius)
        {
            Radius = radius;
        }

        public override float Area => (float)(Math.PI * Radius * Radius);

        public override PointF CenterPoint => new PointF(0, 0);

        public override PointF AxeMoment()
        {
            var J = (float)(Math.PI * Math.Pow(Radius, 4) / 4);
            return new PointF(J, J);
        }

        public override float CenterMoment()
        {
            return 0;
        }

        public override void Draw(Graphics g, Pen p)
        {
            g.DrawEllipse(p, -Radius, -Radius, 2 * Radius, 2 * Radius);
        }

        public override List<PointF> GetCorners(float rotate = 0)
        {
            return new List<PointF> {
                new PointF(Radius, 0),
                new PointF(0, Radius),
                new PointF(-Radius, 0),
                new PointF(0, -Radius)
            };
        }

        public override string ToString()
        {
            return $"C {Radius} 0";
        }
    }
}
