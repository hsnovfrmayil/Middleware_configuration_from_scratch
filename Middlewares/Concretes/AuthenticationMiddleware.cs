using System;
using System.Net;
using System.Text;
using Lesson_2_Middleware.Middlewares.Abstracts;

namespace Lesson_2_Middleware.Middlewares.Concretes;

public class AuthenticationMiddleware : IMiddleware
{
    public HttpHandler? Next { get ; set; }

    public void Handler(HttpListenerContext context)
    {
        Console.WriteLine("Authentification has worked...");
        string? username = context.Request.QueryString["username"];
        string? password = context.Request.QueryString["password"];

        if(username=="Admin" && password == "123")
        {
            Next?.Invoke(context);
        }
        else
        {
            context.Response.OutputStream.Write(Encoding.UTF8.GetBytes("User login olunmayib"));
        }
    }
}

