using SopromatLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moment3
{
    class Program
    {

        static void Main(string[] args)
        {
            IBaseShape t;
            IConcreteShape c;
            Material baseMaterial = MaterialFactory.Materials[0];
            t = new BaseRectangle(100, 20);
            ConcreteParameters p = new ConcreteParameters(20, 30, 0, MaterialFactory.Materials[0], baseMaterial);
            c = new ConcreteShape(t, p);

            Console.WriteLine(c.GetDetails());
            Console.WriteLine(c.GetDetails(new System.Drawing.PointF(0, 0)));
            Console.WriteLine(c.GetDetails(new System.Drawing.PointF(10, 10)));
            Console.WriteLine(c.GetDetails(new System.Drawing.PointF(70, 40)));

            Console.ReadKey();
        }
    }
}
