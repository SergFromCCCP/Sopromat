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
            if (f.DialogResult != DialogResult.OK) return;
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
                textBox1.Text = cs.GetDetails(new PointF(float.Parse(txtX.Text), float.Parse(txtY.Text)));
                DrawShape(pictureBox1, cs);
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void DrawShape(Control c, SopromatLib.CompositeShape cs)
        {
            var g = c.CreateGraphics();
            g.Clear(this.BackColor);
            g.TranslateTransform(c.ClientRectangle.Width / 2, c.ClientRectangle.Height / 2);
            g.ScaleTransform(1, -1);
            g.DrawLine(Pens.Gray, -c.ClientRectangle.Width / 2, 0, c.ClientRectangle.Width / 2, 0);
            g.DrawLine(Pens.Gray, 0, -c.ClientRectangle.Height / 2, 0, c.ClientRectangle.Height / 2);
            cs.Draw(g, null);
            g.ResetTransform();
        }

        private void txtX_TextChanged(object sender, EventArgs e)
        {
            Solution();
        }
    }
}
