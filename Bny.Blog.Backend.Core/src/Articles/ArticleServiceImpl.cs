using System;
using System.Collections.Generic;
using Bny.Blog.Backend.Core.Configuration;
using Bny.Blog.Backend.Core.IOC;
using Bny.Blog.Backend.Core.Logging;

namespace Bny.Blog.Backend.Core.Articles
{
	public class ArticleServiceImpl : IArticleService
	{
	    private List<Article> articles = new List<Article>();
	    private IArticleLoader articleLoader;
	    private IArticleParser articleParser;
	    private IConfiguration configuaration;
	
	    public ArticleServiceImpl(IArticleLoader articleLoader, 
								  IArticleParser articleParser, 
								  IConfiguration configuaration)
	    {
	        this.configuaration = configuaration;
	        this.articleParser = articleParser;
	        this.articleLoader = articleLoader;
	    }
	
	    private int LoadArticles()
	    {
	        //Loading md-files from the configurated article source
			var articleSource = configuaration.GetProperty(BnyConfig.BNY_ARTICLE_SOURCE);
			IOCContainer.Get<ILogging>().Debug(String.Format("Loading articles from source {0}",
															 articleSource));
	        articles = new List<Article>(articleLoader.LoadArticles(articleParser,articleSource, "*.md"));
			IOCContainer.Get<ILogging>().Debug(String.Format("Loaded {0} articles from article source {1}",
															 articles.Count, 
															 articleSource));
			return articles.Count;
	    }
	
	    #region IArticleService implementation
	
	    public int ReloadArticles()
	    {
			return LoadArticles();
	    }
	
	    public Article GetArticle(string articleName)
	    {
	        return articles.Find(a => a.FileName == articleName);
	    }
	    public IReadOnlyCollection<Article> GetAllArticles()
	    { 
			return articles.AsReadOnly();
	    }
	
	    public IReadOnlyCollection<Article> GetByTag(string tag)
		{
			var ret = new List<Article>();
			foreach(var article in articles)
			{
				var tags = article.MetaData.TagsArray;
				foreach(var t in tags)
				{
					if(t.ToUpper().Trim() == tag.ToUpper())
					{
						ret.Add(article);
					}
				}
			}
			return ret;
		}
	
	    #endregion
	};
}
