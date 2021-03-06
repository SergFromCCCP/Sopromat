﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SopromatLib
{
    public abstract class BaseShape : IBaseShape
    {
        public abstract float Area { get; }
        public abstract PointF CenterPoint { get; }
        public abstract float CenterMoment();
        public abstract PointF AxeMoment();

        public virtual void Draw(Graphics g, Brush brush)
        {
            g.FillPath(brush, path);
            g.DrawPath(Pens.Gray, path);
        }
        public abstract List<PointF> GetCorners(float rotate = 0);

        public string Name { get; private set; }
        internal System.Drawing.Drawing2D.GraphicsPath path=new System.Drawing.Drawing2D.GraphicsPath();

        protected BaseShape(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }

        public string GetDetails()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine($"БАЗОВАЯ ФИГУРА: {Name}");
            s.AppendLine($" Площадь: {Area:0.000}");
            s.AppendLine($" Центр масс: {CenterPoint.ToString()}");
            s.AppendLine($" Моменты относительно центра масс:");
            s.AppendLine($"  осевой: {AxeMoment():0.000}");
            s.AppendLine($"  центробежный: {CenterMoment():0.000}");
            s.AppendLine($" Углы: {string.Join(", ", GetCorners().Select(z=>z.ToString()))}");
            return s.ToString();
        }
    }
}
