using Dumpify;
using MicroWebFramework.Common;
using MicroWebFramework.Exeptions;

namespace MicroWebFramework.Pipelines;



public class EndPointPipeline : BasePipe
{
    public EndPointPipeline(Action<HttpContext> context) : base(context){}
    public EndPointPipeline():base(){}
    public override void Handler(HttpContext httpContext)
    {
        try
        {
            // Get Controller and Action name from Url
        }
        catch (IPExeptionHandler ex) { ex.Message.Dump(); }
        catch (ControllerExeptionHandler ex) { ex.Message.Dump(); }
        catch (ActionExeptionHandler ex) { ex.Message.Dump(); }
    }
}

