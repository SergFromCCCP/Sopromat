using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SopromatLib
{
    public interface IBaseShape
    {
        float Area { get; }
        PointF CenterPoint { get; }
        float CenterMoment();
        PointF AxeMoment();
        void Draw(Graphics g, Pen p);
        List<PointF> GetCorners(float rotate = 0);
        string GetDetails();
    }
}
