using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class Apointment
    {
        public long Id { get; set; }
        public long? AdminUserId { get; set; }
        public long? UserId { get; set; }
        public long? MachineryId { get; set; }
        public int? State { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public DateTime? ApointmentTime { get; set; }
    }
}
