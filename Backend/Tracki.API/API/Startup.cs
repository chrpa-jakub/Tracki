using API.Helpers;
using API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
			});

			services.AddIdentity<ApplicationUser, IdentityRole>(options =>
					options.Password = new PasswordOptions
					{
						RequireDigit = false,
						RequiredLength = 6,
						RequireLowercase = false,
						RequireUppercase = false,
						RequireNonAlphanumeric = false
					})
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			   .AddJwtBearer(options =>
			   options.TokenValidationParameters = new TokenValidationParameters
			   {
				   ValidateIssuer = false,
				   ValidateAudience = false,
				   ValidateLifetime = true,
				   ValidateIssuerSigningKey = true,
				   IssuerSigningKey = new SymmetricSecurityKey(
				   Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
				   ClockSkew = TimeSpan.Zero
			   });

			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = new PathString("/api/auth");
				options.AccessDeniedPath = new PathString("/api/auth");
				;
				options.Events.OnRedirectToLogin = context =>
				{
					context.Response.StatusCode = StatusCodes.Status401Unauthorized;
					return Task.CompletedTask;
				};
			});

			services.AddCors(o => o.AddPolicy("AllAllowed", builder =>
			builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials()));

			services.AddScoped<JWTTokenHelper>();
			services.AddScoped<AzureStorageService>();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
			}

            app.UseRouting();
			app.UseCors("AllAllowed");
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseHttpsRedirection();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
