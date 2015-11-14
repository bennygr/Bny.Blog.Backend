using System.Collections.Generic;

namespace Bny.Blog.Backend.Core.Articles
{
	/// <summary>
	///		Loads articles
	/// </summary>
	public interface IArticleLoader
	{
		/// <summary>
		///		Loads an article from a given resource, for example a full file name
		/// </summary>
	    /// <param name = "parser">A parser which parses the article content</param>
		/// <param name="resource">
		///		The full name of the resource representing the article, for example a full path to a file
		/// </param>
		Article LoadArticle(IArticleParser parser, string resource);
	
		/// <summary>
		///		Loads all articles from a given resource, for example a full file name
		/// </summary>
	    /// <param name = "parser">A parser which parses the article content</param>
		/// <param name="resource">
		///		The full name of the resource representing the article's location, for example a full path to a directory
		/// </param>
		/// <param name="pattern">
		///		A pattern describing which articles to load from the resource, for example "*.md" for md-files
		/// </param>
		IEnumerable<Article> LoadArticles(IArticleParser parser, string resource,string pattern);
	};
}
