using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SopromatLib
{
    public class Material
    {
        public Material(string name, float e)
        {
            Name = name;
            E = e;
        }

        public string Name { get; private set; }
        public float E { get; private set; }
    }
}
