using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Business.DependencyResolvers.Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac;

namespace WebAPI
{
    /// <summary>
    /// Api'ye senin kendi IOC 'i yapýn var ama Ben Autofac'in IOC 'i yapýsýný kullanmak istiyorum diyoruz.
    /// .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    /// .ConfigureContainer<ContainerBuilder>(builder=>
    ///  {
    ///        builder.RegisterModule(new AutofacBusinessModule());
    ///  }) 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                  .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                  .ConfigureContainer<ContainerBuilder>(builder => {

                      builder.RegisterModule(new AutofacBusinessModule());
                  })
                  
                   .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
