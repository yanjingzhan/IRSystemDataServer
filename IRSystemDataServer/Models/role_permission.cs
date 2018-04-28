namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.role_permission")]
    public partial class role_permission
    {
        public long id { get; set; }

        public long? roleId { get; set; }

        public long? permissionId { get; set; }

        public DateTime? createTime { get; set; }

        public DateTime? modifiedTime { get; set; }
    }
}
