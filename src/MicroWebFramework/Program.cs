using Dumpify;
using MicroWebFramework.Pipelines;
using MicroWebFramework.Common;
using System.Net;
using System.Net.Sockets;

HttpListener http = new();
var server = "http://localhost:5058/";
http.Prefixes.Add(server);
Console.WriteLine($"start {server} ...");

try
{
    http.Start();
    while (true)
    {
        HttpListenerContext httpContext = http.GetContext();

        Task.Run(() => HandleRequest(httpContext));
    }

}
catch (HttpListenerException ex)
{
    $"HttpListenerException: {ex.Message}".Dump();
}
finally
{
    http.Stop();
}

void HandleRequest(HttpListenerContext httpContext)
{
    try
    {
        HttpContext request = new() { Context = httpContext };



        var pipeline = new PipelineBuilder()
            .AddPipe<AuthenticationPipeline>()
            .AddPipe<EndPointPipeline>()
            .Build();



        pipeline(request);
    }
    catch (Exception ex)
    {
        $"Exception: {ex.Message}".Dump();
        httpContext.Response.StatusCode = 500;
    }
    finally
    {
        httpContext.Response.Close();
    }
}