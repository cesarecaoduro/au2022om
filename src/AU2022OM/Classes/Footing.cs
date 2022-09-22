using AU2022OM.Core;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AU2022OM.Classes{
    public class Footing : ElementBase{
        public double Width { get; set; }
        public double Length { get; set; }
        public double Depth { get; set; }
        public Placement Placement { get; set; } = new Placement(0,0,0);
        public override string ToString()
        {
            return $@"(Footing [WxLxD]) [{this.Width}x{this.Length}x{this.Depth}]";
        }

        public string ToJson(Footing f)
        {
            return JsonSerializer.Serialize(f);
        }
    }
}