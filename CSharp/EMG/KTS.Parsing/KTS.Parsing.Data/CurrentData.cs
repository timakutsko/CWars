using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTS.Parsing.Data
{
    public sealed class CurrentData
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Difference { get; set; }
        public string Value { get; set; }
        public DateTime Time { get; set; }
    }
}
