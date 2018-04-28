using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class Machinery
    {
        public long Id { get; set; }
        public string Machinecode { get; set; }
        public string Machinefile { get; set; }
        public string ProductType { get; set; }
        public string Areaid { get; set; }
        public string Address { get; set; }
        public sbyte? IsDeleted { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
