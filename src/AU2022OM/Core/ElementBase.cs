using System;
using System.Collections.Generic;
using System.Text;

// ElementBase.cs
namespace AU2022OM.Core
{
    public partial class ElementBase : ObjectBase
    {
        public Guid Id => Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Dictionary<string, object>? CustomData { get; set; }
    }
}
