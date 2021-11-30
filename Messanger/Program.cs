using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Messanger
{
	public class Program
	{
		///////// по умолчанию /////////
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}


		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});

		/////////
		
		
		public class ChatHub : Hub
		{
			public async Task Send(string message, string userName)
			{
				await this.Clients.All.SendAsync("Send", message, userName);
			}
		}
	}
}
