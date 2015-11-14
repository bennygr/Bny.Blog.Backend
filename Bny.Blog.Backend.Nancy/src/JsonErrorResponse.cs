using System;
using Nancy;
using Nancy.Responses;

namespace Bny.Blog.Backend.Nancy
{
	public class JsonErrorResponse : JsonResponse
	{
	    public Exception Exception{get; private set;}
	
		public JsonErrorResponse (Exception exception)
			: base(exception,new DefaultJsonSerializer())
		{
	        this.Exception = exception;
			this.StatusCode = HttpStatusCode.InternalServerError;
		}
	};
}
