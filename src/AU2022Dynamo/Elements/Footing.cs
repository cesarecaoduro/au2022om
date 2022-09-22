using AU2022OM.Classes;
using Autodesk.DesignScript.Geometry;
using Autodesk.DesignScript.Runtime;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elements
{
    public static class Footing
    {
        [MultiReturn("footing", "placement","base","solid","json")]
        public static Dictionary<string, object> Create(
            Placement placement,
            double width = 1,
            double length = 1,
            double depth = 1,
            string name = "MyFooting"
            )
        {
            var footing = new AU2022OM.Classes.Footing()
            {
                Width = width,
                Length = length,
                Depth = depth,
                Name = name,
                Placement = placement
            };

            var dynPlacement = Point.ByCoordinates(placement.X, placement.Y, placement.Z);

            Rectangle rBase = Rectangle.ByWidthLength(width, length);
            Rectangle rBaseTranslated = rBase.Translate(placement.X, placement.Y, placement.Z) as Rectangle;

            var solid = rBaseTranslated.ExtrudeAsSolid(-depth);
            

            var jsonOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return new Dictionary<string, object>()
            {
                {"footing" , footing },
                {"placement" ,  dynPlacement},
                {"base" , rBaseTranslated },
                {"solid" , solid },
                {"json" , JsonSerializer.Serialize(footing, jsonOptions) }
            };
        }
    }
}
