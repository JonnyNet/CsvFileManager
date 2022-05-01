using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace ChallengeIdentidadTechnologies.Api.Filters
{
	public class ExceptionHandlingAttribute : ExceptionFilterAttribute
	{
		private const string _ERROR_MESSAGE = "An unexpected error occurred. Contact the system administrator.";
		private const string _CONTENT_TYPE = "application/json";
		public override void OnException(ExceptionContext context)
		{
			var statusCode = HttpStatusCode.InternalServerError;
			var errorMessage = _ERROR_MESSAGE;

			if (context.Exception is ArgumentException)
			{
				statusCode = HttpStatusCode.BadRequest;
				errorMessage = context.Exception.Message;
			}

			context.HttpContext.Response.ContentType = _CONTENT_TYPE;
			context.HttpContext.Response.StatusCode = (int)statusCode;
			context.Result = new JsonResult(new
			{
				error = errorMessage,
			});
		}
	}
}
