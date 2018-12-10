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

        //public BaseCircleSector(float radius, float angleRadian) : this(radius, (int)(angleRadian / Math.PI * 180))
        //{
        //    Radius = radius;
        //    AngleRadian = angleRadian;
        //}

        public BaseCircleSector(float radius, int angleDegree) : base($"Сектор радиус: {radius}, угол раскрытия: {angleDegree}")
        {
            Radius = radius;
            AngleDegree = angleDegree;
            AngleRadian = (float)(angleDegree * Math.PI / 180);
        }

        public override float Area => AngleRadian * Radius * Radius / 2;

        public override PointF CenterPoint => new PointF(0, 0);

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
            return $"CS {Radius} {AngleDegree}";
        }
    }
}
