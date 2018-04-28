using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class DoctorReportOption
    {
        public long Id { get; set; }
        public long? CategoryId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public sbyte? IsActive { get; set; }
    }
}
