using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeathValley.Models
{
    public class CacheData
    {
        public int CacheDataId { get; set; }
        public double PointX { get; set; }
        public double PointY { get; set; }
        public int? ParamId { get; set; }
        public virtual Param Param { get; set; }
    }
}