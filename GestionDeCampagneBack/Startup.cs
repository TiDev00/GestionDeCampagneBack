//using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using GestionDeCampagneBack.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GestionDeCampagneBack
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
            services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddControllers();
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "https://localhost:44332",
                    ValidAudience = "https://localhost:44332",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superGCSecretKey@11"))
                };
            });

            services.AddCors(option => option.AddPolicy("GestionCampagnePolicy", builder => {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

            }));
            services.AddScoped<IRole, RoleService>();
            services.AddScoped<IUtilisateur, UtilisateurService>();
            services.AddScoped<IModele, ModeleService>();
            services.AddScoped<ICanalEnvoi, CanalEnvoiService>();
            services.AddScoped<IContact, ContactService>();
            services.AddScoped<INiveauDeVisibilite, NiveauDeVisibiliteService>();
            services.AddScoped<ISuiviCampagne, SuiviCampagneService>();
            services.AddScoped<IContactCanalEnvoi, ContactCanalEnvoiService>();
            services.AddScoped<IListeDiffussion, ListeDiffusionService>();
            services.AddScoped<IContactListeDiffusion, ContactListeDiffusionService>();
            services.AddDbContextPool<DbcontextGC>(options => options.UseSqlServer(
                    Configuration.GetConnectionString("CampagneConnection"))); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("GestionCampagnePolicy");

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
