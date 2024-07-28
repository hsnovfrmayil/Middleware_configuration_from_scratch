using System;
using Lesson_2_Middleware.Middlewares.Concretes;

namespace Lesson_2_Middleware.Hosts;

public interface IStartup
{
    void Configure(MiddlewareBuilder builder);
}

