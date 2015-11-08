using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace ArgsHandler
{
    public class Params
    {
       
        public static string InputFolder { get; set; }        
        public static string OutputFolder { get; set; }
        public static string FindReplace { get; set; }
        

        public static void parseAppConfig()
        {
            var vCustomParameters = ConfigurationManager.GetSection("CustomParameters") as NameValueCollection;
            if (vCustomParameters != null)
            {
                foreach (var pKey in vCustomParameters.AllKeys)
                {
                    string pValue = vCustomParameters.GetValues(pKey).FirstOrDefault();
                    if ("InputFolder".Equals(pKey)) { Params.InputFolder = pValue; }                    
                    else if ("OutputFolder".Equals(pKey)) { Params.OutputFolder = pValue; }
                    else if ("FindReplace".Equals(pKey)) { Params.FindReplace = pValue; }
                }
            }

            if (String.IsNullOrEmpty(Params.InputFolder))
            {
                Console.WriteLine("parseAppConfig() - Missing InputFolder parameter");
                throw new Exception("Missing arguments in App.config");
            }
        }

        public static void parseCmdArgs(string[] args)
        {

            if (args.Length == 0)
            {
                parseAppConfig();
                return;
            }
            else
            {
                parseAppConfig();
                ConsoleCmdLine console = new ConsoleCmdLine();

                CmdLineString _inputFolder = new CmdLineString("i", true, "Specify Input Folder");
                CmdLineString _outputFolder = new CmdLineString("o", true, "Specify Output Folder");
                CmdLineString _findReplace = new CmdLineString("f", false, "Specify Find Replace String in deliter sets of @@ and || ex: left||right@@l2||r2@@l3||r3");
                
                console.RegisterParameter(_inputFolder);
                console.RegisterParameter(_outputFolder);
                console.RegisterParameter(_findReplace);
                console.Parse(args);

                InputFolder = _inputFolder;
                OutputFolder = _outputFolder;
                FindReplace = _findReplace;
             
            }


        }


        //public static void ConfigLogging()
        //{

        //    FileAppender fileAppender = new FileAppender();
        //    fileAppender.AppendToFile = true;
        //    fileAppender.LockingModel = new FileAppender.MinimalLock();
        //    fileAppender.File = @"C:\temp\Logfile.log";

        //    log4net.Layout.PatternLayout pl = new log4net.Layout.PatternLayout();
        //    //d:timestamp t:thread p:level c:Class name m:message n:new line
        //    //pl.ConversionPattern = "%d [%2%t] %-5p [%-10c] %m%n";
        //    pl.ConversionPattern = "%d|%-5p|[%-10c]|%m%n";
        //    pl.ActivateOptions();

        //    fileAppender.Layout = pl;
        //    fileAppender.ActivateOptions();

        //    log4net.Config.BasicConfigurator.Configure(fileAppender);

        //}
    }

}
