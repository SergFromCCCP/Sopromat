using System;
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

        public abstract void Draw(Graphics g, Pen p);
        public abstract List<PointF> GetCorners(float rotate = 0);

        public string Name { get; private set; }

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
            s.AppendLine($"Базовая фигура: {Name}");
            s.AppendLine($" Площадь: {Area:0.000}");
            s.AppendLine($" Моменты относительно центра масс:");
            s.AppendLine($"  осевой: {AxeMoment():0.000}");
            s.AppendLine($"  центробежный: {CenterMoment():0.000}");
            return s.ToString();
        }
    }
}
