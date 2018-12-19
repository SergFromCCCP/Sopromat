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
        private float width_2, height_2;
        private float width_3, height_3;
        public BaseTriangle(float width, float height) : base($"Прямоугольный треугольник, ширина {width}, высота {height}")
        {
            Width = width;
            Height = height;
            width_2 = width * width;
            width_3 = width_2 * width;
            height_2 = height * height;
            height_3 = height_2 * height;
            path.AddPolygon(new[] { new PointF(0, 0), new PointF(0, Height), new PointF(Width, 0) });
        }

    public override float Area => Width * Height / 2;

    public override PointF CenterPoint => new PointF(Width / 3, Height / 3);

    public override PointF AxeMoment()
    {
        return new PointF(Math.Abs(Width * height_3 / 36), Math.Abs(width_3 * Height / 36));
    }

    public override float CenterMoment()
    {
        return -Math.Sign(Width * Height) * (width_2 * height_2) / 72;
    }

    //public override void Draw(Graphics g, Brush b)
    //{
    //    g.FillPolygon(b, new[] { new PointF(0, 0), new PointF(0, Height), new PointF(Width, 0) });
    //}

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
