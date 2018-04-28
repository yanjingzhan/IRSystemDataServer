using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class Permission
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public sbyte? IsDeleted { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
