using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public sbyte? IsMale { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordSalt { get; set; }
        public string Password { get; set; }
        public sbyte? IsEmailVerified { get; set; }
        public sbyte? IsPhoneVerified { get; set; }
        public sbyte? IsDeleted { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public DateTime? Birthday { get; set; }
        public long? PrepayCard { get; set; }
        public string IdCard { get; set; }
    }
}
