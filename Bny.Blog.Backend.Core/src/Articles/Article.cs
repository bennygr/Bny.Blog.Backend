using System;
using Bny.Blog.Backend.Core.Configuration;
using Bny.Blog.Backend.Core.IOC;

namespace Bny.Blog.Backend.Core.Articles
{
	/// <summary>
	///		A blog article
	/// </summary>
	public class Article
	{
		/// <summary>
		///		The unique name of the article
		/// </summary>
		public string FileName{get;set;}
	
		/// <summary>
		///		The article's metadata
		/// </summary>
		public ArticleMetaData MetaData{get;set;}
	
		/// <summary>
		///		The plain content of the article as string
		/// </summary>
		public string Content{get;set;}
	
		/// <summary>
		///		The preview of the article's content
		/// </summary>
		public string Preview
		{
			get
			{
				return Content.Substring(0,MetaData.PreviewLength);
			}
		}
	
		public string QuickEditLink
		{
			get
			{
				var config = IOCContainer.Get<IConfiguration>();
				var link = config.GetProperty(BnyConfig.BNY_QUICK_EDIT_LINK,null);
				if(!String.IsNullOrEmpty(link))
				{
					return String.Format(link,FileName);
				}
				return null;
			}
		}
	};
}
