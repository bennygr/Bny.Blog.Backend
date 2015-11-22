using System.IO;
using Bny.Blog.Backend.Core.Articles;
using System.Text.RegularExpressions;

/// <summary>
///		Publishs articles which are in preview mode
/// </summary>
class Publisher
{
	/// <summary>
	///		Publishs the article
	/// </summary>
	/// <param name="article">The article which should be published</param>
	public void Publish(Article article)
	{
		var articleContent = File.ReadAllText(article.FullFileName);
		articleContent = Regex.Replace(articleContent,"PreviewCode:\".*\"",string.Empty);
		File.WriteAllText(article.FullFileName,articleContent);
	}
};
