using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class MembershipType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? DurationInDays { get; set; }
        public int? DefaultCheckupTimes { get; set; }
        public decimal? Price { get; set; }
    }
}
