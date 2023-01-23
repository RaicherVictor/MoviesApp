using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Middleware {
	public static class LodActorsMiddelwareExtensions {
        public static IApplicationBuilder LogInform(this IApplicationBuilder builder) {
            return builder.UseMiddleware<LogActorsMiddelware>();
        }
    }
}