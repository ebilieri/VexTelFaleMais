using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using VexTel.Repository.Context;

namespace VexTel.App.TestIntegration.Fixtures
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

                ////var connectionString = "server=remotemysql.com;userid=2hNtbAnF4H;password=ete1uXVHp6;database=2hNtbAnF4H";
                //var connectionString = "server=localhost;userid=root;password=mysql@2019;database=VexTelAngularDB";

                //// Configurar context banco de dados
                //services.AddDbContext<VexTelContext>(option =>
                //        option.UseLazyLoadingProxies()
                //            .UseMySql(connectionString, m =>
                //                m.MigrationsAssembly("VexTel.Repository")));

                var serviceProvider = new ServiceCollection()
                  .AddEntityFrameworkInMemoryDatabase()
                  .BuildServiceProvider();

                services.AddDbContext<VexTelContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryEmployeeTest");
                    options.UseInternalServiceProvider(serviceProvider);
                });

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
