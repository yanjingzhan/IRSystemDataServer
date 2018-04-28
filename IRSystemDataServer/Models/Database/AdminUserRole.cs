using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class AdminUserRole
    {
        public long Id { get; set; }
        public long? AdminUserId { get; set; }
        public long? RoleId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
