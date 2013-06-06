namespace FileVer
{
    /// <summary>
    /// The command line arguments for the program
    /// </summary>
    public class ProgramArgs
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ProgramArgs"/> is version.
        /// </summary>
        /// <value>
        ///   <c>true</c> if only the version of the assembly should be written out; otherwise, <c>false</c>.
        /// </value>
        public bool Version { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ProgramArgs"/> is name.
        /// </summary>
        /// <value>
        ///   <c>true</c> if name; otherwise, <c>false</c>.
        /// </value>
        public bool Name { get; set; }
    }
}
