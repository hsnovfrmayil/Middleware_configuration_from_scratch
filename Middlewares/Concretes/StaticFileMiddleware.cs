using System;
using System.Net;
using Lesson_2_Middleware.Middlewares.Abstracts;

namespace Lesson_2_Middleware.Middlewares.Concretes;

public class StaticFileMiddleware : IMiddleware
{
    public HttpHandler? Next { get; set; }

    public void Handler(HttpListenerContext context)
    {
        Console.WriteLine("StaticFile has worked...");
        if (Path.HasExtension(context.Request.Url.AbsolutePath))
        {
            string? path = $"/Users/fermayilhesenov/Projects/Lesson_2_Middleware/Lesson_2_Middleware/Views/";
            try
            {
                string? fileName = context.Request.Url.AbsolutePath.Substring(1);
                path = $"/Users/fermayilhesenov/Projects/Lesson_2_Middleware/Lesson_2_Middleware/Views/{fileName}";

                if (Path.GetExtension(fileName) != ".html")
                    path = $"/Users/fermayilhesenov/Projects/Lesson_2_Middleware/Lesson_2_Middleware/wwwroot/{fileName}";

                var bytes = File.ReadAllBytes(path);
                context.Response.OutputStream.Write(bytes,0,bytes.Length);
                context.Response.ContentType = GetContentType(path);
            }
            catch(Exception ex)
            {
                path = $"/Users/fermayilhesenov/Projects/Lesson_2_Middleware/Lesson_2_Middleware/Views/404.html";
                var bytes = File.ReadAllBytes(path);
                context.Response.OutputStream.Write(bytes, 0, bytes.Length);
                context.Response.ContentType = GetContentType(path);
            }
        }
        Next?.Invoke(context);
    }
    private string GetContentType(string path)
    {
        string contentType;

        string extension = Path.GetExtension(path).ToLower();

        switch (extension)
        {
            case ".css":
                contentType = "text/css";
                break;
            case ".js":
                contentType = "text/javascript";
                break;
            case ".html":
            case ".htm":
                contentType = "text/html";
                break;
            case ".png":
                contentType = "image/png";
                break;
            case ".jpg":
            case ".jpeg":
                contentType = "image/jpeg";
                break;
            case ".gif":
                contentType = "image/gif";
                break;
            case ".ico":
                contentType = "image/x-icon";
                break;
            case ".json":
                contentType = "application/json";
                break;
            case ".xml":
                contentType = "application/xml";
                break;
            case ".pdf":
                contentType = "application/pdf";
                break;
            case ".zip":
                contentType = "application/zip";
                break;
            case ".mp4":
                contentType = "video/mp4";
                break;
            case ".mp3":
                contentType = "audio/mpeg";
                break;
            default:
                contentType = "application/octet-stream"; // Bilinmeyen türler için varsayılan değer
                break;
        }

        return contentType;
    }
}

