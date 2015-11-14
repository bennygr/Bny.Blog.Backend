using LightCore;
using LightCore.Lifecycle;
using Bny.Blog.Backend.Core.Articles;
using Bny.Blog.Backend.Core.Configuration;
using Bny.Blog.Backend.Core.Configuration.Filesystem;
using Bny.Blog.Backend.Core.Logging;

namespace Bny.Blog.Backend.Core.IOC
{
	public static class IOCContainer
	{
		private static IContainer container;
	
		public static void Build()
		{
			var builder = new ContainerBuilder();
			//logging
			builder.Register<ILogging,Logger>().ControlledBy<SingletonLifecycle>();
			//Config
			builder.Register<IConfiguration,ConfigurationImpl>().ControlledBy<SingletonLifecycle>();
			builder.Register<IConfigurationLoader,FilesystemConfigurationLoader>();
			//Article handling
			builder.Register<IArticleLoader,FileSystemArticleLoader>();
			builder.Register<IArticleParser,TankaMarkdownArticleParser>();
			builder.Register<IArticleService,ArticleServiceImpl>().ControlledBy<SingletonLifecycle>();
			container = builder.Build();
		}
	
		public static T Get<T>()
		{
			return container.Resolve<T>();
		}
	};
}
