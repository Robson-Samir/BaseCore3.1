using Base.Application.Services.Interfaces;
using Base.Domain.Entities.Domain;
using Base.Infrastructure.CrossCutting.Utilities;
using Base.Tests.ConfigTest;
using Newtonsoft.Json;
using NUnit.Framework;
using System;

namespace Base.Tests
{
    public class FluxoTest : InitConfigurationTest
    {
        [Test]
        public void TestRelatorioConsolidado()
        {
            var fluxoService = (IFluxoAppService)Constants.serviceProvider.GetService(typeof(IFluxoAppService));
            Console.WriteLine(JsonConvert.SerializeObject(fluxoService.RelatorioConsolidado()));
        }


        [Test]
        public void UpdateLiberaAcessoUser()
        {
            var json = ReadyJsonFile("Fluxo.json");
            var fluxo = JsonConvert.DeserializeObject<Fluxo>(json);
            var fluxoService = (IFluxoAppService)Constants.serviceProvider.GetService(typeof(IFluxoAppService));
            var response = fluxoService.Pagamento(fluxo);
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
    }
}
