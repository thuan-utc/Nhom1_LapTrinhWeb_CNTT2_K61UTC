using Microsoft.AspNetCore.Builder;

namespace Nhom1_LapTrinhWeb_CNTT2_K61
{
	public class Startup
	{
		public void Configure(IApplicationBuilder app)
		{
			app.UseSession();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(5);
			});
		}
	}
}
