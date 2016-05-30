﻿using Microsoft.AspNetCore.Builder;

namespace BookFast.Infrastructure
{
    internal static class SecurityContextExtensions
    {
        public static void UseSecurityContext(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<SecurityContextMiddleware>();
        }
    }
}
