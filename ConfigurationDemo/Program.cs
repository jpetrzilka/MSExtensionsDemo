using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using ConfigurationDemo.ConfigObjects;
using System.Threading;

namespace ConfigurationDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().//later source always overrides its predecessor
               SetBasePath(Path.GetFullPath("Configs")).//must be absolute
               AddJsonFile("config.json", optional: false, reloadOnChange: true).
                                                        //AddXmlFile("xmlsettings.json", optional: false, reloadOnChange: false).
                                                        //AddIniFile("inisettings.json", optional: true, reloadOnChange: false).
               AddEnvironmentVariables().
               AddCommandLine(args);
            var configuration = builder.Build();

            //json settings
            JsonSettings jsonData = new JsonSettings();
            configuration.Bind(jsonData);

            Console.WriteLine("JSON by keys");
            var subSection = configuration.GetSection("passwordRules");
            Console.WriteLine("LockoutDurationMinutes: {0}",
                subSection.GetValue<int>("lockoutDurationMinutes"));
            Console.WriteLine("IgnorePasswordRules: {0}", configuration["IgnorePasswordRules"]);
            //Thread.Sleep(30000);
            //Console.WriteLine("IgnorePasswordRules: {0}", configuration["IgnorePasswordRules"]);
            Console.WriteLine("Users[1]: {0}: {1}", 
                configuration["users:1:login"], 
                configuration["users:1:email"]);
            Console.WriteLine();

            Console.WriteLine("JSON by objects");
            Console.WriteLine("MaxFailedLogins: {0}", jsonData.MaxFailedLogins);
            Console.WriteLine("Users[0]:");
            Console.WriteLine("{0}: {1}", 
                jsonData.Users.First().Login, 
                jsonData.Users.First().Email);
            Console.WriteLine();

            //env. variables
            Console.WriteLine("Environment variables");
            Console.WriteLine("OS variable: {0}", configuration["OS"]);
            Console.WriteLine();

            //command line
            Console.WriteLine("Command line args:");//dash mapping
            Console.WriteLine("Machine name: {0}", configuration["Profile:MachineName"]);
            Console.WriteLine("Version: {0}", configuration["version"]);

            Console.ReadLine();
        }
    }
}
