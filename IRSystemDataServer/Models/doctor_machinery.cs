namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.doctor_machinery")]
    public partial class doctor_machinery
    {
        public long id { get; set; }

        public long doctorId { get; set; }

        public long machineId { get; set; }

        [StringLength(255)]
        public string doctorName { get; set; }

        [StringLength(255)]
        public string doctorPhone { get; set; }

        [StringLength(255)]
        public string machineCode { get; set; }

        [StringLength(255)]
        public string machineAddress { get; set; }

        public DateTime? createTime { get; set; }

        public DateTime? modifiedTime { get; set; }

        public sbyte? isDisabled { get; set; }

        public sbyte? isDeleted { get; set; }
    }
}
