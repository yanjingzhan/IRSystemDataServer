namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.machinery")]
    public partial class machinery
    {
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string machinecode { get; set; }

        [Required]
        [StringLength(255)]
        public string machinefile { get; set; }

        [StringLength(255)]
        public string productType { get; set; }

        [StringLength(255)]
        public string areaid { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        public sbyte? isDeleted { get; set; }

        public DateTime? createTime { get; set; }

        public DateTime? modifiedTime { get; set; }
    }
}
