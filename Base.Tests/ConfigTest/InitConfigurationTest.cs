using Base.Application.Api;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;

namespace Base.Tests.ConfigTest
{
    public class InitConfigurationTest
    {
        internal static IServiceScope serviceScope;

        public static IHost Start()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", Environments.Development);
            var host = Program.CreateHostBuilder(Array.Empty<string>()).Build();
            serviceScope = host.Services.GetService<IServiceScopeFactory>().CreateScope();
            return host;
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
