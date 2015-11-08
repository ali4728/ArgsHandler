using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgsHandler
{
    
    public static class Args
    {
        public static Dictionary<String, Arg> map;
        public static int length = 0;

        public static void Register(String key, Arg arg)
        {
            if (map == null)
            {
                map = new Dictionary<string, Arg>();
            }
            map.Add(key, arg);
            length++;
        }

        public static void Parse(String[] args, out bool help)
        {
            help = false;
            if (args.Length != 0)
            {
                if (args[0].TrimStart('/', '-').Equals("h", StringComparison.InvariantCultureIgnoreCase) || args[0].TrimStart('/', '-').Equals("help", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Available command line arguments are:");
                    foreach (KeyValuePair<String, Arg> arg in map)
                    {
                        Console.WriteLine(arg.Value.help);

                    }
                    help = true;
                    return;
                }
                if (args.Length % 2 != 0)
                {
                    Console.WriteLine("Argument Length is not even. Missing argument key or value");
                    Console.WriteLine(String.Join(" ", args));
                    Validate();
                    throw new Exception("Argument Length is not even. Missing argument key or value");
                }
                else
                {
                    foreach (KeyValuePair<String, Arg> arg in map)
                    {
                        Arg ar = arg.Value;

                        for (int i = 0; i < args.Length; i++)
                        {

                            if (args[i].TrimStart('/', '-').Equals(arg.Key, StringComparison.InvariantCultureIgnoreCase) && args.Length >= (i + 2))
                            {
                                ar.exist = true;
                                ar.val = args[i + 1];
                            }
                        }
                    }
                }
            }
            else //args.length == 0
            {

            }

            Validate();

        }//Parse

        public static void Validate()
        {
            StringBuilder sb = new StringBuilder();
            int errcount = 0;
            foreach (KeyValuePair<String, Arg> arg in map)
            {
                Arg ar = arg.Value;
                if (ar.req && !ar.exist)
                {
                    errcount++;
                    if (errcount == 1)
                    {
                        sb.AppendLine("Please provide required arguments listed below:");
                    }
                    sb.AppendLine(ar.help);
                }
            }
            if (errcount > 0)
            {
                Console.WriteLine(sb.ToString());
                throw new ArgumentException(sb.ToString());

            }
        }

        public static void PrintArgs()
        {
            foreach (KeyValuePair<String, Arg> arg in map)
            {
                Arg ar = arg.Value;
                Console.WriteLine(String.Format("Key: {0} Value: {1} Required: {2} Exist: {3} Help: {4}", arg.Key, ar.val, ar.req.ToString(), ar.exist.ToString(), ar.help));
            }
        }
    }

    public class Arg
    {
        public Arg()
        {
        }

        public Arg(bool req, String help)
        {
            this.req = req;
            this.help = help;
        }


        public String val { get; set; }
        public bool req { get; set; }
        public String help { get; set; }
        public bool exist { get; set; }

    }

 
}
