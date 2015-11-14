namespace Bny.Blog.Backend.Core.Articles
{
	/// <summary>
	///		Parses article files
	/// </summary>
	public interface IArticleParser
	{
		Article Parse(string fileName, string content);
	};
}
