using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SopromatLib
{
    public static class BaseShapeFactory
    {
        private static Dictionary<string, Func<float[], IBaseShape>> dict =
        new Dictionary<string, Func<float[], IBaseShape>> {
                { "R", z => new BaseRectangle(z[0], z[1]) },
                { "T", z => new BaseTriangle(z[0], z[1]) },
                { "C", z => new BaseCircle(z[0]) },
                { "CS", z => new BaseCircleSector(z[0], (int)(z[1])) }
        };

        private static ConcreteParameters GetConcreteParameters(string[] data)
        {
            return new ConcreteParameters(
                new PointF(float.Parse(data[0]), float.Parse(data[1])),
                int.Parse(data[2]),
                MaterialFactory.GetMaterial(data[3]),
                MaterialFactory.GetMaterial(data[4])
                );
        }

        public static IConcreteShape GetConcreteShape(string constructor)
        {
            if (constructor.StartsWith("-"))
                constructor = constructor.Substring(1);
            var p = constructor.Split(' ');
            var b = GetBaseShape(p);
            var c = GetConcreteParameters(p.Skip(3).ToArray());
            return new ConcreteShape(b, c);
        }

        private static IBaseShape GetBaseShape(string[] data)
        {
            return dict[data[0]](data.Skip(1).Take(2).Select(z => float.Parse(z)).ToArray());
        }
        //public static BaseRectangle GetRectangle(float width, float height)
        //{
        //    return new BaseRectangle(width, height);
        //}

        //public static BaseRectangle GetRectangle(string constructor)
        //{
        //    if (!constructor.Trim().ToUpper().StartsWith("R"))
        //        throw new ArgumentException("Строка должна начинаться с R");
        //    var p = constructor.Split(' ');
        //    if (p.Count() < 3)
        //        throw new ArgumentException();
        //    try
        //    {
        //        return new BaseRectangle(float.Parse(p[1]), float.Parse(p[2]));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }
        //}
    }
}
