

using Lesson_2_Middleware.Hosts;

WebHost webHost = new WebHost(27001);

webHost.UseStartup<Startup>();

webHost.Run();