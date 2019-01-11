using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SignalRClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://*:5000", "https://*:5001")
            .UseKestrel(options =>
            {
                //options.Listen(IPAddress.Loopback, 5000);
                //options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                //{
                //    //listenOptions.UseHttps("localhost.pfx", "Nacho-123");
                //});
            })
            //.UseKestrel(options => {
            //    //options.Listen(System.Net.IPAddress.Loopback, 5000); //HTTP port
            //    //options.Listen(System.Net.IPAddress.Loopback, 9000); //HTTPS port
            //    //options.ListenAnyIP(5000);
            //    //options.ListenAnyIP(9000);
            //    options.ListenLocalhost(5000);
            //    options.ListenLocalhost(9000);
            //})
            .UseContentRoot(Directory.GetCurrentDirectory())
            //.UseIISIntegration()
            .UseStartup<Startup>()
            //.UseUrls(_hostingUrls)
            ;
    }
}
