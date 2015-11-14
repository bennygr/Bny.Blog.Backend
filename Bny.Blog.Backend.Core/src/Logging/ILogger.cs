namespace Bny.Blog.Backend.Core.Logging
{
	/// <summary>
	///		A simple interface representing a logger
	/// </summary>
	public interface ILogger
	{
	    /// <summary>
	    /// Logging 
	    /// </summary>
	    /// <param name="level">the message's level</param>
	    /// <param name="message">the message to log</param>
	    void LogMessage(LogLevel level, string message);
	}
}
