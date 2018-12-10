using SopromatLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moment3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IBaseShape t;
            IConcreteShape c;
            Material baseMaterial = MaterialFactory.Materials[0];
            t = new BaseRectangle(100, 20);

            CompositeShape cc = new CompositeShape();

            ConcreteParameters p;
            p = new ConcreteParameters(0, 0, 0, MaterialFactory.Materials[0], baseMaterial);
            cc.Add(new ConcreteShape(t, p));
            p = new ConcreteParameters(0, 20, 0, MaterialFactory.Materials[1], baseMaterial);
            cc.Add(new ConcreteShape(t, p));
            p = new ConcreteParameters(0, 40, 0, MaterialFactory.Materials[1], baseMaterial);
            cc.Add(new ConcreteShape(t, p));

            //Console.WriteLine(cc.GetDetails());

            Console.WriteLine(cc.GetDetails(new System.Drawing.PointF(0, 0)));
            //Console.WriteLine(cc.GetDetails(new System.Drawing.PointF(10, 10)));
            Console.WriteLine(cc.GetDetails(cc.CenterPoint));

            Console.WriteLine(cc.ToString());
            Console.ReadKey();
        }
    }
}
