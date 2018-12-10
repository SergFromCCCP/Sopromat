using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SopromatLib;

namespace TestForm
{
   public class ShapeParser
    {
        public string ShapeToString(IConcreteShape shape)
        {
            return shape.ToString();
        }
    }
}
