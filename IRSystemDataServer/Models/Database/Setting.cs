﻿using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class Setting
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Operator { get; set; }
        public string Description { get; set; }
        public sbyte? IsDeleted { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
