using System;
using Lesson_2_Middleware.Middlewares.Concretes;

namespace Lesson_2_Middleware.Hosts;

public class Startup : IStartup
{
    public void Configure(MiddlewareBuilder builder)
    {
        builder.UseMiddleware<LoggerMiddleware>();
        builder.UseMiddleware<AuthenticationMiddleware>();
        builder.UseMiddleware<StaticFileMiddleware>();
    }
}

