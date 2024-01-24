using MicroWebFramework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroWebFramework.Pipelines;


public class PipelineBuilder
{
    private List<Type> _pipes = new();

    public PipelineBuilder AddPipe<T>()
    {
        _pipes.Add(typeof(T));
        return this;
    }
    public Action<HttpContext> Build()
    {
        var lastIndex = _pipes.Count -1 ;
        var selectedPipe = Activator.CreateInstance(_pipes[lastIndex],null) as BasePipe;

        for (int i = lastIndex - 1; i >= 0; i--)
        {
            selectedPipe = Activator.CreateInstance(_pipes[i], new[] {selectedPipe.Handler }) as BasePipe;
        }
        var firstPipe = Activator.CreateInstance(_pipes[0], new[] { selectedPipe.Handler }) as BasePipe;

        return firstPipe.Handler;
    }
}
