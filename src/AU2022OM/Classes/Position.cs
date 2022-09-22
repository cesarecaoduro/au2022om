using AU2022OM.Geometry;

namespace AU2022OM.Classes{
    public class Position : Point3
    {
        public Position(double x, double y, double z) : base(x, y, z)
        {
        }

        public override string ToString()
        {
            return $@"(Position) [{this.X},{this.Y},{this.Z}]";
        }
    }
}