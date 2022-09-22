using AU2022OM.Core;

namespace AU2022OM.Classes{
    public class Footing : ObjectBase{
        public double Width { get; set; }
        public double Length { get; set; }
        public double Depth { get; set; }
        public Position Origin { get; set; } = new Position(0,0,0);
        public override string ToString()
        {
            return $@"(Footing [WxLxD]) [{this.Width}x{this.Length}x{this.Depth}]";
        }
    }
}