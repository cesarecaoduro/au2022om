using System;
using System.Collections.Generic;

namespace AU2022OM.Core{
    public abstract class ObjectBase{
        public Guid Id => Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Dictionary<string,object>? CustomData { get; set; }
    }
}