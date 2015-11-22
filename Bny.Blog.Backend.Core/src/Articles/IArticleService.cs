
using System.Collections.Generic;

namespace Bny.Blog.Backend.Core.Articles
{
	public interface IArticleService
	{
		/// <summary>
		///		Loads all articles
		/// </summary>
		/// <returns>The number of article loaded</returns>
		int ReloadArticles();
	
		/// <summary>
		///		Gets a specific article by name
		/// </summary>
		/// <param name="articleName">The unique name of the article</param>
		/// <returns>The article with the given unique name, or null if no such article was found</returns>
		Article GetArticle(string articleName);

		/// <summary>
		///		Gets a specific article by preview code
		/// </summary>
		/// <param name="previewCode">The unique preview code of the article</param>
		/// <returns>The article with the given preview code, or null if no such article was found</returns>
		Article GetArticleByPreviewCode(string previewCode);

		/// <summary>
		///		Publishs an article by removing the preview code form the article
		/// </summary>
		/// <param name="article">The article to publish</param>
		void PublishArticle(Article article);
	
		/// <summary>
		///		Gets all known articles
		/// </summary>
		/// <returns>A collection of all known articles</returns>
	    IReadOnlyCollection<Article> GetAllArticles();
	
		/// <summary>
		///		Gets articles by tag
		/// </summary>
		/// <param name="tag">The tag to get articles for</param>
	    IReadOnlyCollection<Article> GetByTag(string tag);
	};
}
