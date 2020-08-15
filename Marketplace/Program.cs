using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Marketplace
{
  public static  class Program
  {
    static Program() => Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    public static void Main(string[] args)
    {
      var configuration = BuildConfiguration(args);

      ConfigureWebHost(configuration).Build().Run();
    }

    private static IConfiguration BuildConfiguration(string[] args)
      => new ConfigurationBuilder()
        .SetBasePath(Environment.CurrentDirectory)
        .Build();

    private static IWebHostBuilder ConfigureWebHost(IConfiguration configuration)
      => new WebHostBuilder()
        .UseStartup<Startup>()
        .UseConfiguration(configuration)
        .ConfigureServices(services => services.AddSingleton(configuration))
        .UseContentRoot(Environment.CurrentDirectory)
        .UseKestrel();
  }
}
