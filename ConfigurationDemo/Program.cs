﻿using System;
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
            var builder = new ConfigurationBuilder().
               SetBasePath("Configs").
               AddJsonFile("jsonsettings.json", optional: false, reloadOnChange: true).
               AddXmlFile("xmlsettings.json", optional: false, reloadOnChange: false).
               AddIniFile("inisettings.json", optional: true, reloadOnChange: false).
               AddEnvironmentVariables().
               AddCommandLine(args);
            var configuration = builder.Build();

            var settings = new MySettings();
            configuration.Bind(settings);

            var moduleSettings = new MyModuleSettings();
            configuration.GetSection("SectionA").Bind(moduleSettings);

            Console.WriteLine($"My application name is '{settings.ApplicationName}'");
            Console.WriteLine($"My module name is '{moduleSettings.ModuleName}'");

            Console.ReadLine();
        }
    }
}
