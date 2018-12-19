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
        private static Dictionary<string, Func<float[], IBaseShape>> dict =
                                    new Dictionary<string, Func<float[], IBaseShape>> {
                                                { "R", z => new BaseRectangle(z[0], z[1]) },
                                                { "T", z => new BaseTriangle(z[0], z[1]) },
                                                { "C", z => new BaseCircle(z[0]) },
                                                { "CS", z => new BaseCircleSector(z[0], (int)(z[1])) }
                                    };

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

            GetHelp();
            while (true)
            {
                Console.Write("Enter command: ");
                var answer = Console.ReadLine().Trim().ToUpper();
                if (answer.StartsWith("Q"))
                    break;
                var command = answer.Split()[0];
                if (!dict.ContainsKey(command))
                {
                    GetHelp();
                    continue;
                }
                try
                {
                    var bs = ShapeFactory.GetConcreteShape(answer);
                    Console.WriteLine(bs.GetDetails(new System.Drawing.PointF(0,0)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(answer);
                    Console.WriteLine(ex.Message);
                }

            }
        }

        private static void GetHelp()
        {
            Console.WriteLine("-----H.E.L.P.------------");
            Console.WriteLine("Формат конструктора:");
            Console.WriteLine("<Команда> V1 V2 X Y Angle [материал_текущий материал_базовый]");
            Console.WriteLine(" Параметры: X,Y,Angle - координаты начальной точки и угол поворота фигуры");
            Console.WriteLine("Команда:");
            Console.WriteLine(" Q - выход");
            Console.WriteLine(" H - этот экран");
            Console.WriteLine(" R - прямоугольник (ширина, высота)");
            Console.WriteLine(" T - треугольник (ширина, высота)");
            Console.WriteLine(" C - круг (радиус, 0)");
            Console.WriteLine(" CS - круговой сектор (радиус, угол раскрытия)");
            Console.WriteLine("Треугольник прямоугольный, начало в точке прямого угла");
            Console.WriteLine("Сектор симметричный относительно вертикальной оси,\nначальная точка - центр круга");
            Console.WriteLine("-----H.E.L.P.------------");
        }
    }
}
