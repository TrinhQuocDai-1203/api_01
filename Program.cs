using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/hello", () => "Hello World");

//cổng chạy
var url = "http://localhost:5170/hello";

// chạy thì sẽ bật web lên
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
