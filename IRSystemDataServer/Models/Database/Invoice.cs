using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class Invoice
    {
        public long Id { get; set; }
        public long? AdminUserId { get; set; }
        public long? MachineryId { get; set; }
        public long? MembershipId { get; set; }
        public decimal? Price { get; set; }
        public sbyte? IsPaid { get; set; }
        public string PayType { get; set; }
        public string PayAccount { get; set; }
    }
}
