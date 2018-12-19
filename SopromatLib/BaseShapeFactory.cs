using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SopromatLib
{
    public static class ShapeFactory
    {
        private class ShapeConstructor
        {
            public string Name;
            public Func<float[], BaseShape> constructor;
        }

        private static Dictionary<string, ShapeConstructor> dict =
            new Dictionary<string, ShapeConstructor> {
                { "R", new ShapeConstructor {
                    Name = "Прямоугольник",
                    constructor = (z) => new BaseRectangle(z[0], z[1]) }
                },
                { "T", new ShapeConstructor {
                    Name = "Треугольник",
                    constructor = (z) => new BaseTriangle(z[0], z[1]) }
                },
                { "C", new ShapeConstructor {
                    Name = "Круг",
                    constructor = (z) => new BaseCircle(z[0]) }
                },
                { "CS", new ShapeConstructor {
                    Name = "Круговой сектор",
                    constructor = (z) => new BaseCircleSector(z[0], (int)(z[1])) }
                }
            };


        //private static Dictionary<string, Func<float[], IBaseShape>> dict =
        //    new Dictionary<string, Func<float[], IBaseShape>> {
        //            { "R", z => new BaseRectangle(z[0], z[1]) },
        //            { "T", z => new BaseTriangle(z[0], z[1]) },
        //            { "C", z => new BaseCircle(z[0]) },
        //            { "CS", z => new BaseCircleSector(z[0], (int)(z[1])) }
        //};

        public static ConcreteParameters GetConcreteParameters(string[] data)
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
            if (parameters.Count() < 6)
                throw new ArgumentException("Формат конструктора: <Команда> V1 V2 X Y Angle [материал_текущий материал_базовый]");
            if (parameters.Count() == 6)
            {
                parameters = (constructor + " " + MaterialFactory.Materials[0].Name + " " + MaterialFactory.Materials[0].Name).Split(' ');
            }
            try
            {
                var baseShape = GetBaseShape(parameters);
                var concreteParameters = GetConcreteParameters(parameters.Skip(3).ToArray());
                return new ConcreteShape(baseShape, concreteParameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        private static BaseShape GetBaseShape(string[] data)
        {
            return dict[data[0]].constructor(data.Skip(1).Take(2).Select(z => float.Parse(z)).ToArray());
        }

        public static IEnumerable<KeyValuePair<string, string>> GetBaseNames()
        {
            return dict.Select(d => new KeyValuePair<string, string>(d.Key, d.Value.Name));
        }

        //public static string GetShapeKey(string name)
        //{
        //    return dict.Single(d => d.Value.Name == name).Key;
        //}
    }
}
