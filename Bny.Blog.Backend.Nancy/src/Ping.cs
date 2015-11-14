using System;
using Bny.Blog.Backend.Core.IOC;
using Bny.Blog.Backend.Core.Logging;
using Nancy;
using Bny.Blog.Backend.Nancy;

namespace Bny.Blog.Backend.Core.Configuration
{
	public class Ping : NancyModule
	{
	    public Ping()
	    {
	        var logging = IOCContainer.Get<ILogging>();
	
	        Get["/ping"] = parameters =>
	        {
	            try
	            {
	                logging.Debug(String.Format("PING from {0}",Request.UserHostAddress));
					return "PONG";
	            }
	            catch (Exception e)
	            {
					return new JsonErrorResponse(e);
	            }
	        };
	    }
	};
}
