using System;
using System.Net;

namespace Lesson_2_Middleware.Middlewares.Abstracts;

public delegate void HttpHandler(HttpListenerContext context);

public interface IMiddleware
{
    HttpHandler? Next { get; set; }
    void Handler(HttpListenerContext context);
}
