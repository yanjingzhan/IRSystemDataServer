namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.nine_ask")]
    public partial class nine_ask
    {
        public int id { get; set; }

        public int? aId { get; set; }

        [StringLength(255)]
        public string name { get; set; }
    }
}
