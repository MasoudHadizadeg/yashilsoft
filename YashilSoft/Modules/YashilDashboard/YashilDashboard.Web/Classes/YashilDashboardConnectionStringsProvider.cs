using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Native;
using DevExpress.DataAccess.Web;
using Microsoft.Extensions.Configuration;

namespace YashilDashboard.Web.Classes
{
    public class YashilDashboardConnectionStringsProvider : IDataSourceWizardConnectionStringsProvider
    {
        private readonly Dictionary<string, DataConnectionParametersBase> _connectionStrings =
            new Dictionary<string, DataConnectionParametersBase>();

        public const string DefaultConnectionStringsSectionName = "ConnectionStrings";

        public YashilDashboardConnectionStringsProvider(IConfiguration configuration)
            : this(configuration, "ConnectionStrings")
        {
        }

        public YashilDashboardConnectionStringsProvider(IConfiguration configuration, string sectionName)
        {
            if (configuration == null)
                return;
            foreach (var configurationSection in configuration.GetSection(sectionName).GetChildren())
            {
                var child = (ConfigurationSection) configurationSection;
                this._connectionStrings.Add(child.Key, new CustomStringConnectionParameters(child.Value));
            }
        }

        Dictionary<string, string> IDataSourceWizardConnectionStringsProvider.GetConnectionDescriptions()
        {
            return this._connectionStrings.Keys.ToDictionary(key => key, key => key);
        }

        DataConnectionParametersBase IDataSourceWizardConnectionStringsProvider.GetDataConnectionParameters(
            string name)
        {
            _connectionStrings.TryGetValue(name, out var connectionParametersBase);
            return connectionParametersBase;
        }
    }
}