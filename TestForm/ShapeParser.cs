using SopromatLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForm
{
    public static class ShapeParser
    {
        public static string ShapeToString(IConcreteShape shape)
        {
            return shape.ToString();
        }

        public static string StringShapeConstructor(IEnumerable<string> items)
        {
            return string.Join(Environment.NewLine, items);
        }

        public static IEnumerable<string> StringShapeConstructor(string items)
        {
            return items.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
