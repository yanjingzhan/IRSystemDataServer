namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.setting")]
    public partial class setting
    {
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [Required]
        [StringLength(255)]
        public string value { get; set; }

        [Column("operator")]
        [StringLength(255)]
        public string _operator { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string description { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? createTime { get; set; }

        public DateTime? modifiedTime { get; set; }
    }
}
