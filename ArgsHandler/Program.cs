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

            Args.Register("in", new Arg(true, "-in Specifies folder where the input file is located ex: -in \"C:\\inputfile.txt\""));
            Args.Register("out", new Arg(true, "-out Specifies output folder ex: -out \"C:\\somepath\""));

            try
            {
                bool help = false;
                Args.Parse(args, out help);

                if (help)
                {
                    return;
                }
            }
            catch (Exception)
            {
                Environment.Exit(160);

            }
            
        }
    }
}
