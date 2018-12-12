using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SopromatLib
{
    public class BaseRectangle : BaseShape
    {
        private float Width, Height;

        public BaseRectangle(float width, float height) : base($"Прямоугольник, ширина {width}, высота {height}")
        {
            Width = width;
            Height = height;
        }

        public override float Area => Width * Height;

        public override PointF CenterPoint => new PointF(Width / 2, Height / 2);

        public override float CenterMoment() => 0;

        public override PointF AxeMoment() => new PointF(
            Width * (float)Math.Pow(Height, 3) / 12,
            (float)Math.Pow(Width, 3) * Height / 12);

        public override void Draw(Graphics g, Pen p)
        {
            g.DrawRectangle(p, 0, 0, Width, Height);
        }

        public override List<PointF> GetCorners(float rotate = 0)
        {
            return new List<PointF> {
                new PointF(0, 0),
                new PointF(Width, 0),
                new PointF(0, Height),
                new PointF(Width, Height)
            };
        }
        public override string ToString()
        {
            return $"R {Width} {Height}";
        }
    }

    
}
