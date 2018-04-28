namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.area")]
    public partial class area
    {

        public long id { get; set; }

        [StringLength(255)]
        public string areaid { get; set; }

        [StringLength(255)]
        public string parentId { get; set; }

        [StringLength(255)]
        public string lel { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string mergerName { get; set; }

        [StringLength(255)]
        public string code { get; set; }

        [StringLength(255)]
        public string zipcode { get; set; }

        [Column("short")]
        [StringLength(255)]
        public string _short { get; set; }

        [StringLength(255)]
        public string mergershortname { get; set; }

        [StringLength(255)]
        public string pinyin { get; set; }

        [StringLength(255)]
        public string jianpin { get; set; }

        [StringLength(255)]
        public string first { get; set; }

        public decimal? lng { get; set; }

        public decimal? lat { get; set; }

        public DateTime? createTime { get; set; }

        public DateTime? modifiedTime { get; set; }
    }
}
