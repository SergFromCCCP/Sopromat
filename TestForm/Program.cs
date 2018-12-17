using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var f = new formEditor();
            f.materials = SopromatLib.MaterialFactory.Materials;
            f.baseMaterial = SopromatLib.MaterialFactory.Materials.First();
            Application.Run(f);
        }
    }
}
