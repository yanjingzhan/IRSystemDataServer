using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class InfraredData
    {
        public long Id { get; set; }
        public int? UserId { get; set; }
        public int? AdminUserId { get; set; }
        public byte[] Data { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? WindowStart { get; set; }
        public int? WindowWidth { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? GestureId { get; set; }
        public long? ApointmentId { get; set; }
        public string DataFile { get; set; }
    }
}
