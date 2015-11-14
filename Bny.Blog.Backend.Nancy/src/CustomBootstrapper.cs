using Nancy;
using Nancy.TinyIoc;

namespace Bny.Blog.Backend.Nancy
{
	public class CustomBootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureApplicationContainer(TinyIoCContainer container)                  
		{
			//StaticConfiguration.DisableErrorTraces = false;
		}
	};
}
