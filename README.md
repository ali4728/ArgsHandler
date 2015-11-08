# ArgsHandler
Parse console application command line arguments.

## Examples
<pre>
<code>
	ArgsHandler.exe -i C:\temp\infolder -o C:\temp\outfolder
	
</code>
</pre>

</pre>

Setup:
<pre>
<code>
// first string parameter is the switch identifier followed by Arg object 
// that takes a required/optional boolean and an example string for -help switch to display
            Args.Register("i", new Arg(true, "-i Specifies folder where the input file is located ex: -i \"C:\\inputfile.txt\""));
            Args.Register("o", new Arg(true, "-o Specifies output folder ex: -o \"C:\\somepath\""));

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
</code>
</pre>