namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.doctorreportoption")]
    public partial class doctorreportoption
    {
        public long id { get; set; }

        public long? categoryId { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(200)]
        public string value { get; set; }

        public sbyte? isActive { get; set; }
    }
}
