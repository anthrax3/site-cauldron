using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SiteCauldron.Database;
using Microsoft.EntityFrameworkCore;
using SiteCauldron.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EntityGraphQL.Schema;

namespace SiteCauldron
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) =>
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = Configuration["AuthInfo:ValidIssuer"],
                ValidAudience = Configuration["AuthInfo:ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration["AuthInfo:SecretKey"])
                )
            }.To(tokenValidationParameters =>
                services
                .Do(s => s.AddControllers())
                .Do(s => s.AddDbContext<Context>(options => options
                        .UseSqlServer(Configuration["ConnectionStrings:Local"])))
                        //.UseMySQL(Configuration["ConnectionStrings:LocalMySQL"])))
                .Do(s => s.AddSingleton(SchemaBuilder.FromObject<Context>()))
                .Do(s => s.AddSingleton<ICommonSingletons, CommonSingletons>())
                .Do(s => s.AddSingleton<IEntitiesInfo, EntitiesInfo>())
                .Do(s => s.AddSingleton<IAuthInfoProvider>(new AuthInfoProvider(tokenValidationParameters)))
                .Do(s => s.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => options.TokenValidationParameters = tokenValidationParameters))
            );

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
            env.DoIf(x => x.IsDevelopment())
                    (_ => app.UseDeveloperExceptionPage())
                .Do(_ => app.UseAuthentication())
                .Do(_ => app.UseHttpsRedirection())
                .Do(_ => app.UseRouting())
                .Do(_ => app.UseAuthorization())
                .Do(_ => app.UseEndpoints(endpoints => endpoints.MapControllers()));
    }
}
