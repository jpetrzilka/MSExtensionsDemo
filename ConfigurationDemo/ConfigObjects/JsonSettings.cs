using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationDemo.ConfigObjects
{
    class JsonSettings
    {
        public int MaxFailedLogins { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
