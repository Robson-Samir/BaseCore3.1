using Base.Application.Api;
using Base.Application.Services.Mappers;
using Base.Infrastructure.CrossCutting.IoC;
using Base.Infrastructure.CrossCutting.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.IO;
using System.Linq;

namespace Base.Tests.ConfigTest
{
    public class InitConfigurationTest
    {
        public InitConfigurationTest()
        {
            IConfiguration Configuration;
            IServiceCollection service = new ServiceCollection();
            var ioc = new InjectorContainer();
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();
            Infrastructure.CrossCutting.Logs.Log.Register(Log.Logger);
            service.AddAutoMapper(typeof(MappingProfile));
            service.AddOptions();
            service.Configure<KeysConfig>(Configuration);
            service = Startup.MontaBanco(service, Configuration);
            service.AddMemoryCache();
            ioc.ObterScopo(service, Configuration);
            service.BuildServiceProvider();
        }

        public string ReadyJsonFile(string nameFile)
        {
            string content = "";
            var resouceName = typeof(InitConfigurationTest).Assembly.GetManifestResourceNames().FirstOrDefault(a => a.Contains(nameFile));
            var file = typeof(InitConfigurationTest).Assembly.GetManifestResourceStream(resouceName);

            using (var st = new StreamReader(file))
            {
                string linha = "";
                while ((linha = st.ReadLine()) != null)
                {
                    content += linha;
                }
            }

            return content;
        }
    }
}
