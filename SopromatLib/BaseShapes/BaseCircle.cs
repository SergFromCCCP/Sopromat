using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SopromatLib
{
  public  class BaseCircle:BaseShape
    {
        private float Radius, Angle;
        private int AngleDegree;

        public BaseCircle(float radius, int angleDegree=0):base("Круг радиусом "+radius)
        {
            Radius = radius;
        }

        public override float Area => throw new NotImplementedException();

        public override PointF CenterPoint => throw new NotImplementedException();

        public override PointF AxeMoment()
        {
            throw new NotImplementedException();
        }

        public override float CenterMoment()
        {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics g, Pen p)
        {
            throw new NotImplementedException();
        }

        public override List<PointF> GetCorners(float rotate = 0)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"C {Radius} 0";
        }
    }
}
