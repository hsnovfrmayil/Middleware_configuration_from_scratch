using System;
using System.Net;
using Lesson_2_Middleware.Middlewares.Abstracts;

namespace Lesson_2_Middleware.Middlewares.Concretes;

public class LoggerMiddleware : IMiddleware
{
    public HttpHandler? Next { get; set; }

    public void Handler(HttpListenerContext context)
    {
        Console.WriteLine($"Requested  Loglandi -> {context.Request.RawUrl}");

        Next?.Invoke(context);

        Console.Write("Response Loglandi...");
    }
}

