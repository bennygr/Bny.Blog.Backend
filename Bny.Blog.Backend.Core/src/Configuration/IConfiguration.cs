using System;

namespace Bny.Blog.Backend.Core.Configuration
{
	/// <summary>
	///		Defines a service for accessing configuration properties
	/// </summary>
	public interface IConfiguration
	{
	    /// <summary>
	    ///		Loads configuration properties
	    /// </summary>
	    /// <param name="loader">The loader to read the configuration from</param>
	    void Load(IConfigurationLoader loader);
	
	    /// <summary>
	    ///		Gets a configuration property by name
	    /// </summary>
	    /// <param name="property">The name of the property</param>
	    /// <param name="defaultValue">The default value to return if the property with the given name does not exist</param>
	    string GetProperty(string property, string defaultValue = null);
	
		/// <summary>
		///		Gets a configuration propery by name 
		/// </summary>
	    /// <param name="property">The name of the property</param>
	    /// <param name="defaultValue">The default value to return if the property with the given name does not exist</param>
		int? GetPropertyAsInt(string property, int? defaultValue = null);
	
	    /// <summary>
	    ///		Count of known properties
	    /// </summary>
	    /// <returns>The amount of known configuration properties</returns>
	    int Count{ get; }
	};
}
