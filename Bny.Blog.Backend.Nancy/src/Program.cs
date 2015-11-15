using System;
using System.Threading;
using Bny.Blog.Backend.Core.Articles;
using Bny.Blog.Backend.Core.Configuration;
using Bny.Blog.Backend.Core.IOC;
using Bny.Blog.Backend.Core.Logging;
using Nancy;
using Nancy.Hosting.Self;
using Nancy.Json;

namespace Bny.Blog.Backend.Core.Configuration
{
    class MainClass
    {
        public static int Main(string[] args)
        {
			ILogging logging = null;
			try
			{
				//Setting up the IOC-Container
				IOCContainer.Build();
				//Adding logger
				logging = IOCContainer.Get<ILogging>();
				logging.AddLogger(new ConsoleLogger());
				logging.Debug("------------------------------------------------------------------");
				logging.Debug("bny - a simple and puristic blog engine -");
				
				//Loading configuration
				var config = IOCContainer.Get<IConfiguration>();
				config.Load(IOCContainer.Get<IConfigurationLoader>());
				
				//Loading articles on startup
				IOCContainer.Get<IArticleService>().ReloadArticles();
				int? port = config.GetPropertyAsInt(BnyConfig.BNY_PORT,50118);
				Uri uri = new Uri(String.Format("http://localhost:{0}",port));

				StaticConfiguration.DisableErrorTraces = false;
				JsonSettings.MaxJsonLength = Int32.MaxValue;
				using (var host = new NancyHost(uri))
				{
				    logging.Debug(String.Format("Starting bny.blog REST service on {0} ...",uri));
				    host.Start();
				    logging.Debug("bny.blog has been started and is ready for action");
				    logging.Debug("------------------------------------------------------------------");
				    while (true)
				    {
				        Thread.Sleep(1);
				    }
				}
			}
			catch(Exception e)
			{
				if(logging != null)
				{
					logging.Error("Fatal error: ");
					logging.Error(e.Message);
					logging.Error(e.StackTrace);
				}
				else
				{
					System.Console.WriteLine(e.Message);
					System.Console.WriteLine(e.StackTrace);
				}
				return -1;
			}
			
        }
    }
}
