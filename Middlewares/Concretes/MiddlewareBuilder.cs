using System;
using Lesson_2_Middleware.Middlewares.Abstracts;

namespace Lesson_2_Middleware.Middlewares.Concretes;

public class MiddlewareBuilder
{
	public Stack<Type> _middlewares = new Stack<Type>();

	public void UseMiddleware<T>() where T: IMiddleware
	{
		_middlewares.Push(typeof(T));
	}

	public HttpHandler Build()
	{
		HttpHandler end = c => c.Response.Close();
		while (_middlewares.Count != 0)
		{
			var type = _middlewares.Pop();

			var middleware = Activator.CreateInstance(type) as IMiddleware;
			middleware!.Next = end;
			end = middleware.Handler;
		}
		return end;
	}
}

