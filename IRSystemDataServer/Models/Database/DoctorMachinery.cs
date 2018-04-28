using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class DoctorMachinery
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public long MachineId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorPhone { get; set; }
        public string MachineCode { get; set; }
        public string MachineAddress { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public sbyte? IsDisabled { get; set; }
        public sbyte? IsDeleted { get; set; }
    }
}
