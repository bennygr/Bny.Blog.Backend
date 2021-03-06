namespace Bny.Blog.Backend.Core.Logging
{
	/// <summary>
	///		Interface providing access to all logging functions
	/// </summary>
	public interface ILogging
	{
	    /// <summary>
	    ///		Adds a logger to the logging system
	    /// </summary>
	    /// <param name="logger">the logger to add</param>
	    void AddLogger(ILogger logger);
	
	    /// <summary>
	    ///		Writes a debug message to all registered loggers
	    /// </summary>
	    /// <param name="message">The message</param>
	    void Debug(string message);
	
	    /// <summary>
	    ///		Writes a warning message to all registered logger
	    /// </summary>
	    /// <param name="message">The message</param>
	    void Warning(string message);
	
	    /// <summary>
	    ///		Writes an error message to all registered logger
	    /// </summary>
	    /// <param name="message">The message</param>        
	    void Error(string message);
	};
}
