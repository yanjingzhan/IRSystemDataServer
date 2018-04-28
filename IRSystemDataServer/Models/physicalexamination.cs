namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.physicalexamination")]
    public partial class physicalexamination
    {
        public long id { get; set; }

        public long? userid { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public sbyte? isMale { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        public DateTime? birthday { get; set; }

        [StringLength(255)]
        public string idCard { get; set; }

        public int? age { get; set; }

        public double? height { get; set; }

        public double? weight { get; set; }

        public sbyte? maritalstatus { get; set; }

        public DateTime? modifiedTime { get; set; }

        public DateTime? createTime { get; set; }

        public sbyte? isDeleted { get; set; }

        [StringLength(255)]
        public string doctor { get; set; }

        [Column("operator")]
        [StringLength(255)]
        public string _operator { get; set; }

        public sbyte? mianse_miansefahong { get; set; }

        public sbyte? mianse_miansefahuang { get; set; }

        public sbyte? mianse_mianbuyouban { get; set; }

        public sbyte? mianse_liangjiachaohong { get; set; }
    }
}
