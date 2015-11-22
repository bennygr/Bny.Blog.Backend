using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Bny.Blog.Backend.Core.IOC;
using Bny.Blog.Backend.Core.Logging;

namespace Bny.Blog.Backend.Core.Articles
{
	public class FileSystemArticleLoader : IArticleLoader
	{
	    public Article LoadArticle(IArticleParser parser, string resource)
	    {
	        return LoadArticle(parser, new FileInfo(resource));
	    }
	
	    public Article LoadArticle(IArticleParser parser, FileInfo file)
	    {
			var logging = IOCContainer.Get<ILogging>();
	        var articleText = 
	            File.ReadAllText(file.FullName, Encoding.Default);
			logging.Debug(String.Format("Successfully loaded article {0} from file system.",file.FullName));
			var article =  parser.Parse(file.FullName,articleText);
			return article;
	    }
	
	    public IEnumerable<Article> LoadArticles(IArticleParser parser, string resource, string pattern)
	    {
	        return LoadArticles(parser, new DirectoryInfo(resource), pattern);
	    }
	
	    public IEnumerable<Article> LoadArticles(IArticleParser parser, DirectoryInfo diretory, string pattern)
	    {
			var logging = IOCContainer.Get<ILogging>();
			var ret = new List<Article>();
	        foreach (var file in diretory.GetFiles(pattern))
	        {
				try
				{
					ret.Add(LoadArticle(parser, file));
				}
				catch(Exception e)
				{
					logging.Error("Error loading article " + file.FullName + ": " + e.Message);
					logging.Error(e.InnerException.Message);
					logging.Error(e.StackTrace);
				}
	        }
			//Sorting all loaded articles by date in reverse order
			ret.Sort( (a1,a2) => a1.MetaData.Date.CompareTo(a2.MetaData.Date));
			ret.Reverse();
	
			return ret;
	    }
	};
}
