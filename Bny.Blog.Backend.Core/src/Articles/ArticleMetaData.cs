using System;
using System.Collections.Generic;
using Bny.Blog.Backend.Core.Utils;

namespace Bny.Blog.Backend.Core.Articles
{
	public class ArticleMetaData
	{
		/// <summary>
		///		The title of the article
		/// </summary>
		public string Title{get;set;}
	
		/// <summary>
		///		The creation/update date of the article
		/// </summary>
		public DateTime Date{get;set;}
	
		/// <summary>
		///		The creation/update date of the article as Unix-Time
		/// </summary>
		public double DateJavaScript
		{
			get
			{
				return Date.ToJavaScriptMilliseconds();
			}
		}
	
		/// <summary>
		///		A comma separated list of tags describing the article's content
		/// </summary>
		public string Tags{get;set;}
	
		/// <summary>
		///		A list of tags describing the article's content
		/// </summary>
		public IEnumerable<string> TagsArray
		{
			get
			{
				var tags = Tags.Split(',');
	            foreach (var tag in tags)
	            {
					yield return tag.Trim();
	            }
			}
		}

		/// <summary>
		///		The preview code of the article, or null for productive articles
		/// </summary>
		public string PreviewCode{get;set;}
	
		/// <summary>
		///		The length of text which should be used as preview 
		/// </summary>
		public int PreviewLength{get;set;}
	
		/// <summary>
		///		A short text description of the article
		/// </summary>
		public String Description{get;set;}
	};
}
