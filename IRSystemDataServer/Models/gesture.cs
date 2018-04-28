namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.gesture")]
    public partial class gesture
    {
        public int id { get; set; }

        [StringLength(45)]
        public string name { get; set; }

        [StringLength(45)]
        public string description { get; set; }

        public sbyte? gender { get; set; }

        [StringLength(45)]
        public string gesturecol { get; set; }

        public DateTime? createTime { get; set; }

        public DateTime? modifiedTime { get; set; }

        public sbyte? isActive { get; set; }
    }
}
