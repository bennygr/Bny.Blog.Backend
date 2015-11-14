using System.Collections.Generic;

namespace Bny.Blog.Backend.Core.Configuration
{
	/// <summary>
	///		A loader which loads configuration data from 
	///		a specific source (for example filesystem, Database, etc)
	/// </summary>
	public interface IConfigurationLoader
	{
	    /// <summary>
	    ///		Loads all configuration data
	    /// </summary>
	    IEnumerable<ConfigurationData> LoadData();
	};
}
