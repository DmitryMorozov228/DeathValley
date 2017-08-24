using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeathValley.Models
{
    public class Param
    {
        public int ParamId { get; set; }
        public double CoefficientA { get; set; }
        public double CoefficientB { get; set; }
        public double CoefficientC { get; set; }
        public double Step { get; set; }
        public double RangeFrom { get; set; }
        public double RangeTo { get; set; }
        public virtual ICollection<CacheData> CacheDatas { get; set; }
    }
}