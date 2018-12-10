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
        private Dictionary<string, Func<float[], IBaseShape>> dict =
            new Dictionary<string, Func<float[], IBaseShape>> {
                { "R", z => new BaseRectangle(z[0], z[1]) },
                { "T", z => new BaseTriangle(z[0], z[1]) },
                { "C", z => new BaseCircle(z[0]) },
                { "CS", z => new BaseCircleSector(z[0], (int)(z[1])) }
            };

        public List<Material> materials { get; set; }
        public List<string> shapes { get; set; }
        public Material baseMaterial { get; set; }

        public formEditor()
        {
            InitializeComponent();
        }

        private void formEditor_Load(object sender, EventArgs e)
        {

        }

        private ConcreteParameters GetConcreteParameters()
        {
            return new ConcreteParameters(
                new PointF(float.Parse(txtX.Text), float.Parse(txtY.Text)),
                int.Parse(txtRotate.Text),
                (Material)cboMaterial.SelectedItem,
                baseMaterial
                );
        }

        private IBaseShape GetBaseShape()
        {
            var a = dict[comboBox1.SelectedValue.ToString()];
            return a(GetData());
        }

        private float[] GetData()
        {
            return new float[] { float.Parse(txtData1.Text), float.Parse(txtData2.Text) };
        }
    }
}
