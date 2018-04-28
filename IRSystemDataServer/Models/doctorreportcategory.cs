namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.doctorreportcategory")]
    public partial class doctorreportcategory
    {
        public long id { get; set; }

        public long parentid { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        public int? level { get; set; }

        public sbyte isActive { get; set; }
    }
}
