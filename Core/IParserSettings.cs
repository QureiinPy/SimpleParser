using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserWPF.Core
{
    interface IParserSettings
    {
        string BaseUrl { get; set; }
        string Preffix { get; set; }
        int StartPoint { get; set; }
        int EndPoint { get; set; }
    }
}
