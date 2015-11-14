using System;
using Newtonsoft.Json;

namespace Bny.Blog.Backend.Core.Articles
{
	public abstract class AbstractArticleParser : IArticleParser
	{
	    public ArticleMetaData ParseMetaData(string content)
	    {
			//Parsing the meta data header
	        var header = content.Substring(0, content.IndexOf('>') + 1);
	        header = header.Replace("<!--", "{");
	        header = header.Replace("-->", "}");
	
			//Parse the header itself, because it is json
			return JsonConvert.DeserializeObject<ArticleMetaData>(header);
	    }
	
		public string RemoveMetaData(string content)
		{
			//Parsing the meta data header
	        var header = content.Substring(0, content.IndexOf('>') + 1);
			content =  content.Replace(header,string.Empty);
			//Removing all leading newline chars
			while(content.StartsWith(Environment.NewLine))
			{
				content = content.Substring (1);
			}
			return content;
		}
	
	    #region IArticleParser implementation
	
	    public abstract Article Parse(string fileName, string content);
	
	    #endregion
	};
}
