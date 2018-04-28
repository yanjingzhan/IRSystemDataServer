using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class RolePermission
    {
        public long Id { get; set; }
        public long? RoleId { get; set; }
        public long? PermissionId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
