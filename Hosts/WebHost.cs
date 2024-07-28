using System;
using System.Net;
using Lesson_2_Middleware.Middlewares.Abstracts;
using Lesson_2_Middleware.Middlewares.Concretes;

namespace Lesson_2_Middleware.Hosts;

public class WebHost
{
	private int _port;
    private HttpListener _listener;
    private HttpHandler _requestHandler;
    private MiddlewareBuilder _builder = new MiddlewareBuilder();


    public WebHost(int port)
    {
        _port = port;
        _listener = new HttpListener();
        _listener.Prefixes.Add($"http://127.0.0.1:{_port}/");

    }

    public void UseStartup<T>() where T: IStartup, new()
    {
        var startup = new T();
        startup.Configure(_builder);

         _requestHandler=_builder.Build();
    }

    public void Run()
    {
        _listener.Start();
        Console.WriteLine($"Server started on {_port}");


        while (true)
        {
            HttpListenerContext? context =  _listener.GetContext();

            Task.Run(() =>
            {
                _requestHandler.Invoke(context);
                context.Response.Close();
            });
        }
    }
}

