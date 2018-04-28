using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class Camera
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string Name { get; set; }
        public sbyte? IsMale { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public string IdCard { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public DateTime? CreateTime { get; set; }
        public sbyte? IsDeleted { get; set; }
        public string FaceFilePath { get; set; }
        public string TongueFilePath { get; set; }
        public string HandFrontFilePath { get; set; }
        public string HandBackFilePath { get; set; }
        public string Doctor { get; set; }
        public string Operator { get; set; }
    }
}
