namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.user")]
    public partial class user
    {
        public long id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public bool isMale { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(100)]
        public string phone { get; set; }

        [StringLength(100)]
        public string passwordSalt { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        public bool? isEmailVerified { get; set; }

        public bool? isPhoneVerified { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? createTime { get; set; }

        public DateTime? modifiedTime { get; set; }

        public DateTime? birthday { get; set; }

        public long? prepayCard { get; set; }

        [StringLength(45)]
        public string idCard { get; set; }
    }
}
