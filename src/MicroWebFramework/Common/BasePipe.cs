
namespace MicroWebFramework.Common;


public abstract class BasePipe
{    
    protected readonly Action<HttpContext> _context;
    public BasePipe(Action<HttpContext> context)
    {
        _context = context;
    }
    public BasePipe()
    {
        _context = null;
    }
    public abstract void Handler(HttpContext httpContext);
}

