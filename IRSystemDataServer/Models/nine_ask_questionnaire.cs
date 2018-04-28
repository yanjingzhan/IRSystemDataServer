namespace IRSystemDataServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infraredsystem.nine_ask_questionnaire")]
    public partial class nine_ask_questionnaire
    {
        public long id { get; set; }

        public long? userId { get; set; }

        [StringLength(255)]
        public string nineAsk { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public sbyte? isMale { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        public DateTime? birthday { get; set; }

        [StringLength(255)]
        public string idCard { get; set; }

        public DateTime? modifiedTime { get; set; }

        public DateTime? createTime { get; set; }

        public sbyte? isDeleted { get; set; }
    }
}
