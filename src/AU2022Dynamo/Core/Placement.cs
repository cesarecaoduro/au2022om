using AU2022OM.Classes;
using Autodesk.DesignScript.Runtime;
using System.Collections.Generic;

namespace Core
{
    public static class Placement
    {
        [MultiReturn("placement")]
        public static Dictionary<string, object> Create(
                    double x = 0,
                    double y = 0,
                    double z = 0
                    )
        {
            var placement = new AU2022OM.Classes.Placement(x, y, z);

            return new Dictionary<string, object>()
            {
                {"placement" , placement }
            };
        }
    }
}
