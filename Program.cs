using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Endpoint trả về Hello World
app.MapGet("/hello", () => "Hello World");

// URL bạn muốn tự mở
var url = "http://localhost:5170/hello";

// Khi ứng dụng start thì mở trình duyệt
app.Lifetime.ApplicationStarted.Register(() =>
{
    try
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
    catch { }
});

app.Run("http://localhost:5170");
