namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.apointment")]
    public partial class apointment
    {
        public long id { get; set; }

        public long? adminUserId { get; set; }

        public long? userId { get; set; }

        public long? machineryId { get; set; }

        public int? state { get; set; }

        public DateTime? createTime { get; set; }

        public DateTime? modifiedTime { get; set; }

        public DateTime? apointmentTime { get; set; }
    }
}
