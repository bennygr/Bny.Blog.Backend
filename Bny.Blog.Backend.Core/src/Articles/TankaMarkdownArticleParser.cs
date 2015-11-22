using Tanka.Markdown;
using Tanka.Markdown.Html;

namespace Bny.Blog.Backend.Core.Articles
{
	internal class TankaMarkdownArticleParser : AbstractArticleParser
	{
	    #region IArticleParser implementation
	
	    public override Article Parse(string fileName, string content)
	    {
			var parser = new MarkdownParser();
			string t = RemoveMetaData(content);
			var document = parser.Parse(t);
			var renderer = new MarkdownHtmlRenderer();
	
	        var article = new Article
	        {
	            FullFileName = fileName,
	            Content = renderer.Render(document),
				MetaData = ParseMetaData(content)
	        };
	
			return article;
	    }
	
	    #endregion
	};
}
