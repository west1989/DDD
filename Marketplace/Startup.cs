using Marketplace.ClassifiedAd;
using Marketplace.Domain;
using Marketplace.Domain.ClassifiedAd;
using Marketplace.Domain.Shared;
using Marketplace.Framework;
using Marketplace.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Raven.Client.Documents;

namespace Marketplace
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {

      var store = new DocumentStore
      {
        Urls = new[] {"http://localhost:8080"},
        Database = "Marketplace_Raven",
        Conventions = {FindIdentityProperty = m => m.Name == "DbId" }
      };
      store.Initialize();

      services.AddSingleton<ICurrencyLookup, FixedCurrencyLookup>();
      services.AddScoped(c => store.OpenAsyncSession());
      services.AddScoped<IUnitOfWork, RavenDbUnitOfWork>();
      services.AddScoped<IClassifiedAdRepository, ClassifiedAdRepository>();
      services.AddScoped<ClassifiedAdsApplicationService>();

      services.AddControllers();
      services.AddSwaggerGen(c =>
        c.SwaggerDoc("v1",
          new OpenApiInfo
          {
            Title = "ClassifiedAds",
            Version = "v1"
          }));

      services.AddSingleton<ClassifiedAdsApplicationService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseSwagger();
      app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClassifiedAds v1"));

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

    }
  }
}
