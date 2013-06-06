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
            var path = args[0];

            if (!File.Exists(path))
            {
                Console.WriteLine("{0} was not found", path);
                return -10;
            }

            var asm = Assembly.LoadFile(Path.GetFullPath(path));

            if (command.Name)
            {
                Console.WriteLine(asm.FullName);
            }

            if (command.Version)
            {
                Console.WriteLine(asm.GetName().Version.ToString());
            }

            return 0;
        }
    }
}
