using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Middleware {
	public class LogActorsMiddelware 
		{
        private readonly RequestDelegate _next;

        public LogActorsMiddelware(RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<LogActorsMiddelware> logger) {
            if(httpContext.Request.Path == "/Actors")
            logger.LogTrace($"Request: {httpContext.Request.Path}  Method: {httpContext.Request.Method} Data: {httpContext.Request.Query}");
            await _next(httpContext);
            
        }
    }
}

