using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Ioc
{
 public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
