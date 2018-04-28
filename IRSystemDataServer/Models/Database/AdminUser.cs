using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class AdminUser
    {
        public long Id { get; set; }
        public string Account { get; set; }
        public string PasswordSalt { get; set; }
        public string Password { get; set; }
        public string PhoneNum { get; set; }
        public sbyte? IsDisabled { get; set; }
        public sbyte? IsDeleted { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string Operator { get; set; }
        public string RealName { get; set; }
    }
}
