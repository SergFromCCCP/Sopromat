using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SopromatLib
{
    public class ConcreteParameters
    {
        public PointF Location { get; private set; }
        public int AngleDegree { get; private set; }
        public float AngleRadian { get; private set; }
        public string MaterialName { get; private set; }
        //public Material currentMaterial { get; set; }
        //public Material baseMaterial { get; set; }
        public float Koef { get; private set; }

        public ConcreteParameters(PointF location, int angleDegree, Material currentMaterial, Material baseMaterial)
        {
            Location = location;
            AngleDegree = angleDegree;
            AngleRadian = angleDegree * (float)Math.PI / 180;
            MaterialName = currentMaterial.Name;
            //this.currentMaterial = currentMaterial;
            //this.baseMaterial = baseMaterial;
            Koef = currentMaterial.E / baseMaterial.E;
        }

        public ConcreteParameters(float x, float y, int angleDegree, Material currentMaterial, Material baseMaterial) :
            this(new PointF(x, y), angleDegree, currentMaterial, baseMaterial)
        {
        }

        public string GetDetails()
        {
            return $"Стартовая точка: {Location.ToString()}, угол: {AngleDegree} o, материал: {MaterialName}, коэ-т: {Koef}";
        }

        public override string ToString()
        {
            return $"{Location.X} {Location.Y} {AngleDegree} {MaterialName}";
        }
    }
}
