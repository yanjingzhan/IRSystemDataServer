namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.infrareddata")]
    public partial class infrareddata
    {
        public long id { get; set; }

        public int? userId { get; set; }

        public int? adminUserId { get; set; }

        [Column(TypeName = "mediumblob")]
        public byte[] data { get; set; }

        public int? width { get; set; }

        public int? height { get; set; }

        public int? windowStart { get; set; }

        public int? windowWidth { get; set; }

        public DateTime? createTime { get; set; }

        public DateTime? modifiedTime { get; set; }

        public int? gestureId { get; set; }

        public long? apointmentId { get; set; }

        [StringLength(300)]
        public string dataFile { get; set; }
    }
}
