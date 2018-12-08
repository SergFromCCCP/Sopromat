﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SopromatLib
{
    public class ConcreteShape : IConcreteShape
    {
        IBaseShape baseShape;
        ConcreteParameters parameters;

        public ConcreteShape(IBaseShape baseShape, ConcreteParameters parameters)
        {
            this.baseShape = baseShape;
            this.parameters = parameters;
        }

        public PointF CenterPoint => baseShape.CenterPoint.Rotate(parameters.AngleRadian).Move(parameters.Location);

        public PointF AxeMoment => baseShape.AxeMoment;

        public float Area => baseShape.Area * parameters.Koef;

        public float CenterMoment => baseShape.CenterMoment;

        public void Draw(Graphics g, Pen p)
        {
            throw new NotImplementedException();
        }

        public List<PointF> GetCorners(float rotate = 0)
        {
            return baseShape.GetCorners(parameters.AngleRadian).Move(parameters.Location);
        }

        public string GetDetails()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("GetDetails without point");
            s.AppendLine(baseShape.GetDetails());
            s.AppendLine(parameters.ToString());
            s.AppendLine($"CenterPoint: {CenterPoint.ToString()}");
            s.AppendLine($"Приведенная площадь: {Area}");
            s.AppendLine("Координаты углов:");
            s.AppendLine(string.Join(", ", GetCorners()));
            return s.ToString();
        }

        public string GetDetails(PointF point)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("GetDetails with point");
            s.AppendLine(GetDetails());
            s.AppendLine($" Моменты относительно точки {point.ToString()}");
            s.AppendLine($"  осевой: {GetAxeMoment(point):0.000}");
            s.AppendLine($"  центробежный: {GetCenterMoment(point):0.000}");

            return s.ToString();

        }

        public PointF GetAxeMoment(PointF point)
        {
            var J = baseShape.AxeMoment;
            J.X *= parameters.Koef;
            J.Y *= parameters.Koef;
            var J1 = (J.X + J.Y) / 2;
            var J2 = (float)((J.X - J.Y) / 2 * Math.Cos(-2 * parameters.AngleRadian));
            var J3 = (float)(baseShape.CenterMoment * Math.Sin(-2 * parameters.AngleRadian));
            var Jc = new PointF(J1 + J2 - J3, J1 - J2 + J3);
            return new PointF(
                Jc.X + Area * (float)Math.Pow(CenterPoint.Y - point.Y, 2),
                Jc.Y + Area * (float)Math.Pow(CenterPoint.X - point.X, 2));
        }

        public float GetCenterMoment(PointF point)
        {
            var bmAxe = baseShape.AxeMoment;
            var bmCenter = baseShape.CenterMoment;
            return (float)((bmAxe.X - bmAxe.Y) / 2 * Math.Sin(-2 * parameters.AngleRadian) +
                bmCenter * Math.Cos(-2 * parameters.AngleRadian) +
                Area * (CenterPoint.X - point.X) * (CenterPoint.Y - point.Y));
        }
    }
}
