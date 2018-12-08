using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SopromatLib
{
    public static class MaterialFactory
    {
        public static List<Material> Materials = new List<Material> {
            new Material("Алюминий", 73000),
            new Material("Сталь", 200000),
            new Material("ППУ", 33.5f) };
    }
}
