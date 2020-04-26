
namespace CommonLib.Models
{
    /// <summary>
    ///     Exposes automation test framework configuration options.
    /// </summary>
    public class ConfigurationOptions
    {
        /// <summary>
        ///     Gets or sets the sql connection string.
        /// </summary>
        public string SqlConnection { get; set; }

        /// <summary>
        ///     Gets or sets the running driver type.
        /// </summary>
        public string DriverType { get; set; } = "Chrome";

        /// <summary>
        ///     Gets or sets the flag IeRemoteRun.
        /// </summary>
        public bool IsRemoteRun { get; set; } = false;

        /// <summary>
        ///     Gets or sets the remote url for run.
        /// </summary>
        public string RemoteRunUrl { get; set; }
    }
}
