namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.membership")]
    public partial class membership
    {
        public long id { get; set; }

        public int? type { get; set; }

        public DateTime? beginTime { get; set; }

        public DateTime? expireTime { get; set; }

        public int? remainCheck { get; set; }

        public long? userid { get; set; }

        public long? machineryId { get; set; }

        public DateTime? createTime { get; set; }

        public long? operatorId { get; set; }

        public sbyte isValid { get; set; }
    }
}
