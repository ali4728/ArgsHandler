using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgsHandler
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * Command line arg example
             * -i C:\temp\infolder -o C:\temp\outfolder -f "left||right@@l2||r2@@l3||r3"
             */

            Params.parseCmdArgs(args);
            Console.WriteLine("InputFolder: " + Params.InputFolder);
            Console.WriteLine("InputFolder: " + Params.OutputFolder);

            String[] _outer = Params.FindReplace.Split(new string[] { "@@" }, StringSplitOptions.None);
            foreach (String item in _outer)
            {
                String [] _innter = item.Split(new string[] { "||" }, StringSplitOptions.None);
                foreach (String it in _innter)
                {
                    Console.WriteLine(it);
                }
            }
            Console.WriteLine("Program has completed. Pres enter to exit.");
            Console.ReadLine();

            //Args.Register("in", new Arg(true, "-in Specifies folder where the input file is located ex: -in \"C:\\inputfile.txt\""));
            //Args.Register("out", new Arg(true, "-out Specifies output folder ex: -out \"C:\\somepath\""));

            //try
            //{
            //    bool help = false;
            //    Args.Parse(args, out help);

            //    if (help)
            //    {
            //        return;
            //    }
            //}
            //catch (Exception)
            //{
            //    Environment.Exit(160);

            //}
            
        }
    }
}
