using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using VexTel.Repository.Context;

namespace VexTel.App.TestIntegration
{
    public class TestingWebAppFactory<T> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {

                var descriptor = services.SingleOrDefault(
                  d => d.ServiceType ==
                     typeof(DbContextOptions<VexTelContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkMySql()
                  //.AddEntityFrameworkInMemoryDatabase()
                  .BuildServiceProvider();

                var connectionString = "server=remotemysql.com;userid=2hNtbAnF4H;password=ete1uXVHp6;database=2hNtbAnF4H";

                // Configurar context banco de dados
                services.AddDbContext<VexTelContext>(option =>
                        option.UseLazyLoadingProxies()
                            .UseMySql(connectionString, m =>
                                m.MigrationsAssembly("VexTel.Repository")));

                //services.AddDbContext<VexTelContext>(options =>
                //{
                //    options.UseInMemoryDatabase("InMemoryEmployeeTest");
                //    options.UseInternalServiceProvider(serviceProvider);
                //});

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<VexTelContext>())
                    {
                        try
                        {
                            appContext.Database.EnsureCreated();
                        }
                        catch (Exception ex)
                        {
                            //Log errors or do anything you think it's needed
                            throw;
                        }
                    }
                }
            });
        }
    }
}
