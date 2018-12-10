using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SopromatLib
{
    public class BaseTriangle : BaseShape
    {
        private float Width, Height;
        public BaseTriangle(float width, float height) : base($"Треугольник, ширина {width}, высота {height}")
        {
            Width = width;
            Height = height;
        }

        public override float Area => Width * Height / 2;

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
            return new List<PointF> {
                new PointF(0, 0),
                new PointF(0, Height),
                new PointF(Width, 0)
            };
        }

        public override string ToString()
        {
            return $"T {Width} {Height}";
        }
    }
}
