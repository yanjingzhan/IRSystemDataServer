namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.invoice")]
    public partial class invoice
    {
        public long id { get; set; }

        public long? adminUserId { get; set; }

        public long? machineryId { get; set; }

        public long? membershipId { get; set; }

        public decimal? price { get; set; }

        public sbyte? isPaid { get; set; }

        [StringLength(45)]
        public string payType { get; set; }

        [StringLength(100)]
        public string payAccount { get; set; }
    }
}
