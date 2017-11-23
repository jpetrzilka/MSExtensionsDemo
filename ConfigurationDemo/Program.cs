using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ConfigurationDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().//later source always overrides its predecessor
               SetBasePath(Path.GetFullPath("Configs")).//must be absolute
                                                        //AddJsonFile("jsonsettings.json", optional: false, reloadOnChange: true).
                                                        //AddXmlFile("xmlsettings.json", optional: false, reloadOnChange: false).
                                                        //AddIniFile("inisettings.json", optional: true, reloadOnChange: false).
               AddEnvironmentVariables().
               AddCommandLine(args);
            var configuration = builder.Build();

            //var settings = new MySettings();
            //configuration.Bind(settings);

            //var moduleSettings = new MyModuleSettings();
            //configuration.GetSection("SectionA").Bind(moduleSettings);

            //Console.WriteLine($"My application name is '{settings.ApplicationName}'");
            //Console.WriteLine($"My module name is '{moduleSettings.ModuleName}'");

            //env. variables
            Console.WriteLine("OS variable: {0}", configuration["OS"]);
            Console.WriteLine();

            //command line
            Console.WriteLine("Machine name: {0}", configuration["Profile:MachineName"]);
            Console.WriteLine("Version: {0}", configuration["version"]);

            Console.ReadLine();
        }
    }
}
