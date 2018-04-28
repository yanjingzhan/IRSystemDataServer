namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.admin_user")]
    public partial class admin_user
    {
        public long id { get; set; }

        [Required]
        [StringLength(100)]
        public string account { get; set; }

        [Required]
        [StringLength(255)]
        public string passwordSalt { get; set; }

        [Required]
        [StringLength(255)]
        public string password { get; set; }

        [Required]
        [StringLength(255)]
        public string phoneNum { get; set; }

        public sbyte? isDisabled { get; set; }

        public sbyte? isDeleted { get; set; }

        public DateTime? createTime { get; set; }

        public DateTime? modifiedTime { get; set; }

        [Column("operator")]
        [StringLength(255)]
        public string _operator { get; set; }

        [StringLength(45)]
        public string realName { get; set; }
    }
}
