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
            var parameters = constructor.Split(' ');
            var baseShape = GetBaseShape(parameters);
            var concreteParameters = GetConcreteParameters(parameters.Skip(3).ToArray());
            return new ConcreteShape(baseShape, concreteParameters);
        }

        private static IBaseShape GetBaseShape(string[] data)
        {
            return dict[data[0]](data.Skip(1).Take(2).Select(z => float.Parse(z)).ToArray());
        }
    }
}
