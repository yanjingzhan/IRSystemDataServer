namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.membershiptype")]
    public partial class membershiptype
    {
        public long id { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        public int? durationInDays { get; set; }

        public int? defaultCheckupTimes { get; set; }

        public decimal? price { get; set; }
    }
}
