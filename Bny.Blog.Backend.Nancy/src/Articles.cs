using System;
using System.Collections.Generic;
using Bny.Blog.Backend.Core.Articles;
using Bny.Blog.Backend.Core.IOC;
using Bny.Blog.Backend.Core.Logging;
using Nancy;

namespace Bny.Blog.Backend.Nancy
{
	public class Articles : NancyModule
	{
	    public Articles()
	    {
	        var logging = IOCContainer.Get<ILogging>();
	
	        Get["/articles/"] = parameters =>
	        {
				return ServeArticleList(
						() =>  new List<Article>(IOCContainer.Get<IArticleService>().GetAllArticles())
				);
	        };
	
	        Get["/articles/tags/{tag}"] = parameters =>
	        {
				logging.Debug(String.Format("Searching articles with tags {0}", parameters.tag));
				return ServeArticleList(
						() =>  new List<Article>(IOCContainer.Get<IArticleService>().GetByTag(parameters.tag))
				);
	        };
	
	        Get["/articles/{articleName}"] = parameters =>
	        {
	            try
	            {
	                logging.Debug(String.Format("Searching article with name {0}", parameters.articleName));
	                var articleService = IOCContainer.Get<IArticleService>();
	                var article = articleService.GetArticle(parameters.articleName);
	                if (article != null)
	                {
	                    logging.Debug(String.Format("Article found with name {0}", parameters.articleName));
						return article;
	                }
	                logging.Error(String.Format("No article found with name {0}", parameters.articleName));
	                return HttpStatusCode.NotFound;
	            }
	            catch (Exception e)
	            {
	                return new JsonErrorResponse(e);
	            }
	        };
	    }
	
		private object ServeArticleList(Func<List<Article>> articleQuery)
		{
			try
			{
				var articles = articleQuery();
				var retList = new List<object>();
				foreach(var article in articles)
				{
					retList.Add(article);
				}
				return Negotiate.WithModel(retList).                                            
					WithHeader("ArticleCount",retList.Count.ToString()).                         
					WithHeader("PageSize","10"); 
			}
			catch (Exception e)
			{
				return new JsonErrorResponse(e);
			}
		}
	};
}
