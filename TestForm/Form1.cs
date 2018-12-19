using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new formEditor();
            f.materials = SopromatLib.MaterialFactory.Materials;
            f.baseMaterial = SopromatLib.MaterialFactory.Materials.First();
            f.shapes = SopromatLib.BaseShapeFactory.GetBaseNames().ToList();
            f.ShowDialog();
            var constructor = f.CompositeShapeConstructor;
            var cs = new SopromatLib.CompositeShape();
            foreach (var item in constructor)
            {
                if (item.StartsWith("-"))
                    cs.Substract(SopromatLib.BaseShapeFactory.GetConcreteShape(item));
                else
                    cs.Add(SopromatLib.BaseShapeFactory.GetConcreteShape(item));
            }
            textBox1.Text = cs.GetDetails(new PointF(0, 0));
        }
    }
}
