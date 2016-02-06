using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OElite
{
    public class CalcResult
    {
        public DateTime TimeExecuted { get; set; }
        public string Param1 { get; set; }
        public string Param2 { get; set; }
        public string Result { get; set; }
        public string RequestMethod { get; set; }
        public string RequestUrl { get; set; }
        public string RequestQuery { get; internal set; }
    }
}
