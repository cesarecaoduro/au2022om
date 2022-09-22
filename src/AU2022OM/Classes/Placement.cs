using AU2022OM.Geometry;

namespace AU2022OM.Classes{
    public class Placement : Point3
    {
        public Placement(double x, double y, double z) : base(x, y, z)
        {
        }

        public override string ToString()
        {
            return $@"({nameof(Placement)}) [{this.X},{this.Y},{this.Z}]";
        }
    }
}