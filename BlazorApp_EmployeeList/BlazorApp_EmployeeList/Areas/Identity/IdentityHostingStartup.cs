using System;
using BlazorApp_EmployeeList.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BlazorApp_EmployeeList.Areas.Identity.IdentityHostingStartup))]
namespace BlazorApp_EmployeeList.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BlazorApp_EmployeeListContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BlazorApp_EmployeeListContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<BlazorApp_EmployeeListContext>();
            });
        }
    }
}