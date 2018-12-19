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
            f.shapes = SopromatLib.ShapeFactory.GetBaseNames().ToList();
            f.ShowDialog();
            var constructor = f.CompositeShapeConstructor;
            var cs = new SopromatLib.CompositeShape();
            foreach (var item in constructor)
            {
                if (item.StartsWith("-"))
                    cs.Substract(SopromatLib.ShapeFactory.GetConcreteShape(item));
                else
                    cs.Add(SopromatLib.ShapeFactory.GetConcreteShape(item));
            }
            try
            {
                textBox1.Text = cs.GetDetails(new PointF(0, 0));
                var g = CreateGraphics();
                g.Clear(this.BackColor);
                g.TranslateTransform(0, ClientRectangle.Height);
                g.ScaleTransform(1, -1);
                cs.Draw(g, null);
                g.ResetTransform();
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }
    }
}
