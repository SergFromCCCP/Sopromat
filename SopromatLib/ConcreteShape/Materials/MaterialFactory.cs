using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SopromatLib
{
    public static class MaterialFactory
    {
        private static string fileName = "materials.dat";
        public static List<Material> Materials =
            System.IO.File.Exists(fileName) ?
                ReadFromFile() :
                new List<Material> {
                                    new Material("Алюминий", 73000),
                                    new Material("Сталь", 200000),
                                    new Material("Фанера",5555f),
                                    new Material("ППУ", 33.5f) };

        private static List<Material> ReadFromFile()
        {
            var lines = System.IO.File.ReadAllLines(fileName).Select(z => z.Split(','));
            var result = new List<Material>();
            foreach (var item in lines)
            {
                result.Add(new Material(item[0], float.Parse(item[1].Trim())));
            }
            var r = lines.Select(z => new Material(z[0], float.Parse(z[1].Trim()))).ToList();
            return r;
        }

        public static Material GetMaterial(string name)
        {
            var found = Materials.Find(m => m.Name.ToUpper() == name.ToUpper());
            return found;
        }
    }
}
