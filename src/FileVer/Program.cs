namespace FileVer
{
    using System;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// The <c>FileVer.exe</c> program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Mains the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>The exit code of the application</returns>
        public static int Main(string[] args)
        {
            var command = Args.Configuration.Configure<ProgramArgs>().CreateAndBind(args);
            
            if (command.Help || args.Length == 0)
            {
                Console.WriteLine("FileVer.exe Version: {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
                Console.WriteLine("================================================");
                Console.WriteLine("Usage: FileVer [Assembly Path] <options>");
                Console.WriteLine("  Options:");
                Console.WriteLine("    /help (/h):    This help information");
                Console.WriteLine("    /name (/n):    The full name of the assembly");
                Console.WriteLine("    /version (/v): The version of the assembly.");
                return 0;
            }

            var path = args[0];

            if (!File.Exists(path))
            {
                Console.WriteLine("{0} was not found", path);
                return -10;
            }

            var asm = Assembly.LoadFile(Path.GetFullPath(path));

            if (command.Name || (!command.Version && !command.Name))
            {
                Console.WriteLine(asm.FullName);
                return 0;
            }

            if (command.Version)
            {
                Console.WriteLine(asm.GetName().Version.ToString());
                return 0;
            }

            return 0;
        }
    }
}