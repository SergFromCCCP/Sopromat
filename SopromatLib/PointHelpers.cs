using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SopromatLib
{
    public static class PointHelpers
    {
        public static SizeF ToSizeF(this PointF point) => new SizeF(point.X, point.Y);
        public static PointF Rotate(this PointF point, float angle)
        {
            var cos = (float)Math.Cos(angle);
            var sin = (float)Math.Sin(angle);
            return new PointF(point.X * cos - point.Y * sin, point.X * sin + point.Y * cos);
        }
        public static PointF Move(this PointF point, PointF whereTo) => point + whereTo.ToSizeF();

        public static List<PointF> Rotate(this List<PointF> points, float angle) => points.Select(p => p.Rotate(angle)).ToList();
        public static List<PointF> Move(this List<PointF> points, PointF whereTo) => points.Select(p => p.Move(whereTo)).ToList();

    }
}
