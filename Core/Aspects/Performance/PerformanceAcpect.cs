using Castle.DynamicProxy;
using Core.Ioc;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Performance
{
    public class PerformanceAcpect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;
        public PerformanceAcpect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {

                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.Name}.{invocation.Method.Name}" +
                                $"--> {_stopwatch.Elapsed.TotalSeconds}");
            }

            _stopwatch.Reset();
        }
    }
}
