using Dumpify;
using MicroWebFramework.Common;
using MicroWebFramework.Exeptions;


namespace MicroWebFramework.Pipelines;
public class AuthenticationPipeline(Action<HttpContext> context) : BasePipe(context)
{
    public override void Handler(HttpContext httpContext)
    {
        var UserIpAddress = httpContext.Context.Request.UserHostAddress;
        "check your IP Address".Dump();
        if (string.Compare(UserIpAddress, "192.168.0.130", StringComparison.OrdinalIgnoreCase) == 0)
        {
            throw new IPExeptionHandler(UserIpAddress);
        }
        else
            _context(httpContext);

        "End of checking IP address".Dump();
    }
}
