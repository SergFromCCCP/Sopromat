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
            cboBaseMaterial.DataSource = SopromatLib.MaterialFactory.Materials;
            cboBaseMaterial.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new formEditor();
            f.materials = SopromatLib.MaterialFactory.Materials;
            f.baseMaterial = SopromatLib.MaterialFactory.Materials.First();
            f.shapes = SopromatLib.ShapeFactory.GetBaseNames().ToList();
            f.ShowDialog();
            //string s = "";
            //foreach (var item in f.CompositeShapeConstructor)
            //{
            //    s += item + Environment.NewLine;
            //}
            txtConstructor.Text = ShapeParser.StringShapeConstructor(f.CompositeShapeConstructor);
        }

        private void txtConstructor_TextChanged(object sender, EventArgs e)
        {
            Solution();
        }

        private void cboBaseMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            Solution();
        }

        private void Solution()
        {
            try
            {
                var constructor = ShapeParser.StringShapeConstructor(txtConstructor.Text).Select(z => z + " " + cboBaseMaterial.SelectedItem.ToString());
                var cs = new SopromatLib.CompositeShape();
                foreach (var item in constructor)
                {
                    if (item.StartsWith("-"))
                        cs.Substract(SopromatLib.ShapeFactory.GetConcreteShape(item));
                    else
                        cs.Add(SopromatLib.ShapeFactory.GetConcreteShape(item));
                }
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
