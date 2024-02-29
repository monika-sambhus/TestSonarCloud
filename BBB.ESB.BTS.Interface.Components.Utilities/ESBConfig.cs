namespace ESB.BTS.Components.Interface.Utilities
{
    /// <summary>
    /// Utility class to access ESBConfig db
    /// </summary>
    public class ESBConfig
    {
        // Key in configuration of configuration database connection string
        private const string ConnectionStringKey = "ESBConfig";

        /// <summary>
        /// connection string to the ESBConfig database
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[ConnectionStringKey].ToString();
            }
        }
    }
}
