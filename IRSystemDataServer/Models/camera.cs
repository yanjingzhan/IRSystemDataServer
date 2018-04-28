namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.camera")]
    public partial class camera
    {
        public long id { get; set; }

        public long? userId { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public sbyte? isMale { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        public DateTime? birthday { get; set; }

        [StringLength(255)]
        public string idCard { get; set; }

        public DateTime? modifiedTime { get; set; }

        public DateTime? createTime { get; set; }

        public sbyte? isDeleted { get; set; }

        [StringLength(255)]
        public string faceFilePath { get; set; }

        [StringLength(255)]
        public string tongueFilePath { get; set; }

        [StringLength(255)]
        public string handFrontFilePath { get; set; }

        [StringLength(255)]
        public string handBackFilePath { get; set; }

        [StringLength(255)]
        public string doctor { get; set; }

        [Column("operator")]
        [StringLength(255)]
        public string _operator { get; set; }
    }
}
