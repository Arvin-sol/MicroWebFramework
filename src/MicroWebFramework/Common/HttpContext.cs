using System.Net;

namespace MicroWebFramework.Common;


public class HttpContext
{
    public required HttpListenerContext Context { get; set; }
}

