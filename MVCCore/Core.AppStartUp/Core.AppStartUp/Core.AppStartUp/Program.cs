using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Core.AppStartUp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // call funcion CreateWebHostBuilder to create hosting
            CreateWebHostBuilder(args)
                .Build()
                .Run();
        }

        // config hosting
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>(); // call to Startup.cs page    
    }
}
