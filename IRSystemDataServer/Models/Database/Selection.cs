using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class Selection
    {
        public long Id { get; set; }
        public long InfraredDataId { get; set; }
        public int? Shape { get; set; }
        public int? Left { get; set; }
        public int? Top { get; set; }
        public int? Right { get; set; }
        public int? Bottom { get; set; }
    }
}
