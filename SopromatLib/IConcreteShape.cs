using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace SopromatLib
{
    public interface IConcreteShape : IBaseShape
    {
        //PointF CenterPoint { get; }
        float CenterMoment(PointF point);
        PointF AxeMoment(PointF point);
        void Draw(Graphics g, Pen p);
        List<PointF> GetCorners(float rotate = 0);
        string GetDetails(PointF point);
    }
}
