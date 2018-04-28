using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class DoctorReportCategory
    {
        public long Id { get; set; }
        public long Parentid { get; set; }
        public string Name { get; set; }
        public int? Level { get; set; }
        public sbyte IsActive { get; set; }
    }
}
