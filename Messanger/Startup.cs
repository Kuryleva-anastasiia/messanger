using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Messanger.Models;

namespace Messanger
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSignalR();

			services.AddControllers();

			string connection = Configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<UserContext>(options => options.UseSqlServer(connection));

			// установка конфигурации подключения
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options => //CookieAuthenticationOptions
				{
					options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
				});
			services.AddControllersWithViews();
		}


		public void Configure(IApplicationBuilder app)
		{
			app.UseDeveloperExceptionPage();

			app.UseDefaultFiles();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();    // аутентификация
			app.UseAuthorization();		// авторизация

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "/chat");
			});
		}
	}
}
