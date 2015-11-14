using System;

namespace Bny.Blog.Backend.Core.Utils
{
	/// <summary>
	///		Util class for DateTime extension
	/// </summary>
	public static class DateTimeExtension
	{
	   private static readonly long DatetimeMinTimeTicks =
	      (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks;
	
	   /// <summary>
	   ///		Converts a date time to JavaScript Milliseconds
	   /// </summary>
	   public static long ToJavaScriptMilliseconds(this DateTime dt)
	   {
	         return ((dt.ToUniversalTime().Ticks - DatetimeMinTimeTicks) / 10000);
	   }
	}
}
