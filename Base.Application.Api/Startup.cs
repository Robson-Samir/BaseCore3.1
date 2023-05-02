using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Base.Infrastructure.CrossCutting.Utilities;
using Serilog;
using Base.Infrastructure.CrossCutting.IoC;
using Microsoft.AspNetCore.Http;
using System;
using Base.Application.Services.Mappers;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Base.Application.Api.Attributes;
using Base.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Base.Application.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();           
            Configuration = builder.Build();

            //Serilog para Log
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();
            Infrastructure.CrossCutting.Logs.Log.Register(Log.Logger);
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            // WebAPI Config
            services.AddControllers();

            //MVC 
            services
               .AddMvc(options =>
               {
                   options.Filters.Add(new ApiExceptionFilter());//Tratamento das Exceptions
               })
               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
           
            //AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            //Swagger
            services.AddSwaggerGen(c => {
                c.SwaggerDoc(Configuration["SwaggerVersion"].ToString(),
                new OpenApiInfo
                {
                    Version = Configuration["SwaggerVersion"].ToString(),
                    Title = Configuration["SwaggerTitle"].ToString(),
                    Description = Configuration["SwaggerDescription"].ToString(),
                    Contact = new OpenApiContact { Name = Configuration["SwaggerContactName"].ToString(), Email = Configuration["SwaggerContactEmail"].ToString(), Url = new Uri(Configuration["SwaggerContactUrl"].ToString()) },
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri(Configuration["SwaggerMit"].ToString()) }                    
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Input the JWT like: Bearer {your token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            //Autenticacao JWT - Json Web Token
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })
            .AddJwtBearer("JwtBearer", options =>
            {
                var sec = Encoding.UTF8.GetBytes(Configuration["SecretKey"].ToString());
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(sec),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    //ClockSkew = TimeSpan.FromMinutes(5)
                };
            });

            //Lendo chaves no arquivo de configuracoes
            services.AddOptions();
            services.Configure<KeysConfig>(Configuration);


            services.AddDbContext<DataContext>(options => options.UseSqlServer("",
                    providerOptions =>
                    {
                        providerOptions.CommandTimeout(150000);
                    }), ServiceLifetime.Transient);
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();          

            //Injecao de dependencia nativa
            var ioc = new InjectorContainer();
            services = ioc.ObterScopo(services, Configuration);

            //Adicionar a compressão ao servico
            services.AddResponseCompression();
        }        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            //Serilog para Log                    
            var _loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConfiguration((IConfiguration)Configuration.GetSection("Logging"));
                builder.AddSerilog();                
                builder.AddDebug();

            });
            
            loggerFactory = _loggerFactory;                      
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });
          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", Configuration["SwaggerTitle"].ToString());
            });

            //Adicionar a compressão ao servico
            app.UseResponseCompression();
        }
    }
}
