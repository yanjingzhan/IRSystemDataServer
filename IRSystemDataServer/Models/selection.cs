namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.selection")]
    public partial class selection
    {
        public long id { get; set; }

        public long infraredDataId { get; set; }

        public int? shape { get; set; }

        public int? left { get; set; }

        public int? top { get; set; }

        public int? right { get; set; }

        public int? bottom { get; set; }
    }
}
