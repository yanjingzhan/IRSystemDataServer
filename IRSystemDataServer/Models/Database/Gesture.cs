using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class Gesture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public sbyte? Gender { get; set; }
        public string Gesturecol { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public sbyte? IsActive { get; set; }
    }
}
