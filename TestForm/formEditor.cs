﻿using SopromatLib;
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
    public partial class formEditor : Form
    {
        public List<Material> materials { get; set; }
        public List<KeyValuePair<string, string>> shapes { get; set; }
        public Material baseMaterial { get; set; }
        public IEnumerable<string> CompositeShapeConstructor
        {
            get
            {
                var result = new List<string>();
                foreach (var item in shapeList.Items)
                    result.Add(item.ToString());
                return result;
            }
        }

        public formEditor()
        {
            InitializeComponent();
        }

        private void formEditor_Load(object sender, EventArgs e)
        {
            cboMaterial.DataSource = materials;
            cboMaterial.DisplayMember = "name";

            cboBaseShapes.DataSource = shapes.ToArray();
            cboBaseShapes.DisplayMember = "value";
            cboBaseShapes.ValueMember = "key";

        }

        private string GetShapeConstructor()
        {
            return GetBaseConstructor() + " " + GetConcreteConstructor();
        }
        private string GetBaseConstructor()
        {
            return $"{cboBaseShapes.SelectedValue} {txtData1.Text} {txtData2.Text}";
        }

        private string GetConcreteConstructor()
        {
            return $"{txtX.Text} {txtY.Text} {txtRotate.Text} {(cboMaterial.SelectedItem as Material).Name} {baseMaterial.Name}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //var cs = ShapeFactory.GetConcreteShape(GetShapeConstructor());
            shapeList.Items.Add((checkSubstract.Checked ? "-" : "") + GetShapeConstructor());
        }

        private void cboBaseShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBaseShapes.SelectedValue.ToString())
            {
                case "R":
                case "T":
                    label1.Text = "Ширина";
                    label2.Text = "Высота";
                    break;
                case "CS":
                    label1.Text = "Радиус";
                    label2.Text = "Угол раскрытия";
                    break;
                case "C":
                    label1.Text = "Радиус";
                    break;
                default:
                    break;
            }
        }
    }
}
