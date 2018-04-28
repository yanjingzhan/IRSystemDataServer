using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class Membership
    {
        public long Id { get; set; }
        public int? Type { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? ExpireTime { get; set; }
        public int? RemainCheck { get; set; }
        public long? Userid { get; set; }
        public long? MachineryId { get; set; }
        public DateTime? CreateTime { get; set; }
        public long? OperatorId { get; set; }
        public sbyte IsValid { get; set; }
    }
}
