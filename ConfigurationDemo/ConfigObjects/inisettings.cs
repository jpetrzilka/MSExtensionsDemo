using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationDemo.ConfigObjects
{
    class IniSettings
    {
        public bool LoadDataFromRegistry { get; set; }
        public LoggingInfo Logging { get; set; }
    }
}
