using System;
using System.Collections.Generic;

namespace IRSystemDataServer.Model.Database
{
    public partial class Area
    {
        public long Id { get; set; }
        public string Areaid { get; set; }
        public string ParentId { get; set; }
        public string Lel { get; set; }
        public string Name { get; set; }
        public string MergerName { get; set; }
        public string Code { get; set; }
        public string Zipcode { get; set; }
        public string Short { get; set; }
        public string Mergershortname { get; set; }
        public string Pinyin { get; set; }
        public string Jianpin { get; set; }
        public string First { get; set; }
        public decimal? Lng { get; set; }
        public decimal? Lat { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
