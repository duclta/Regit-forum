using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegitForum.Areas.Identity.Data;
using RegitForum.Models;

[assembly: HostingStartup(typeof(RegitForum.Areas.Identity.IdentityHostingStartup))]
namespace RegitForum.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RegitForumContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RegitForumContextConnection")));

                services.AddDefaultIdentity<RegitForumUser>()
                    .AddEntityFrameworkStores<RegitForumContext>();
            });
        }
    }
}