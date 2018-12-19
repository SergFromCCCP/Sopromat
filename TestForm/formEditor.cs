using SopromatLib;
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
        //private class ShapeConstructor
        //{
        //    public string Name;
        //    public Func<float[], BaseShape> constructor;
        //}

        //private Dictionary<string, ShapeConstructor> dict =
        //    new Dictionary<string, ShapeConstructor> {
        //        { "R", new ShapeConstructor {
        //            Name = "Прямоугольник",
        //            constructor = (z) => new BaseRectangle(z[0], z[1]) }
        //        },
        //        { "T", new ShapeConstructor {
        //            Name = "Треугольник",
        //            constructor = (z) => new BaseTriangle(z[0], z[1]) }
        //        },
        //        { "C", new ShapeConstructor {
        //            Name = "Круг",
        //            constructor = (z) => new BaseCircle(z[0]) }
        //        },
        //        { "CS", new ShapeConstructor {
        //            Name = "Круговой сектор",
        //            constructor = (z) => new BaseCircleSector(z[0], (int)(z[1])) }
        //        }
        //    };

        public List<Material> materials { get; set; }
        public List<KeyValuePair<string, string>> shapes { get; set; }
        public Material baseMaterial { get; set; }
        public IEnumerable<string> CompositeShapeConstructor
        {
            get
            {
                var result = new List<string>();
                foreach (var item in shapeList.Items)
                    result.Add(item.ToString() + " " + baseMaterial.Name);
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

            //var s = dict.Keys.Select(z => new { name = z, value = dict[z].Name });
            cboBaseShapes.DataSource = shapes.ToArray();
            cboBaseShapes.DisplayMember = "value";
            cboBaseShapes.ValueMember = "key";

        }

        //private ConcreteParameters GetConcreteParameters()
        //{
        //    return BaseShapeFactory.GetConcreteParameters(new string[] {
        //        txtX.Text, txtY.Text, txtRotate.Text, cboMaterial.SelectedItem.ToString(), baseMaterial.Name });
        //    //return new ConcreteParameters(
        //    //    new PointF(float.Parse(txtX.Text), float.Parse(txtY.Text)),
        //    //    int.Parse(txtRotate.Text),
        //    //    (Material)cboMaterial.SelectedItem,
        //    //    baseMaterial
        //    //    );
        //}

        //private IBaseShape GetBaseShape()
        //{
        //    var a = dict[cboBaseShapes.SelectedValue.ToString()];
        //    return a.constructor(GetData());
        //}

        //private float[] GetData()
        //{
        //    return new float[] { float.Parse(txtData1.Text), float.Parse(txtData2.Text) };
        //}

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
            var cs = BaseShapeFactory.GetConcreteShape(GetShapeConstructor());
            //var bs = GetBaseShape();
            //var cp = GetConcreteParameters();
            //var cs = new ConcreteShape(bs, cp);
            shapeList.Items.Add((checkSubstract.Checked ? "-" : "") + cs.ToString());
        }
    }
}
