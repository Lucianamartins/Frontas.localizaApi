
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Localizar.frotas.infra.Facade
{
   public class VeiculoDetranFacade : IVeiculoDetran
    {

        private readonly DetranOptions detranOptions;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IveiculoRepository veiculoRepository;

        public VeiculoDetranFacade(IOptionsMonitor<DetranOptions> optionsMonitor, IHttpClientFactory httpClientFactory, IveiculoRepository veiculoRepository)
        {
            this.detranOptions = optionsMonitor.CurrentValue;
            this.httpClientFactory = httpClientFactory;
            this.veiculoRepository = veiculoRepository;
        }

        public async Task AgendarVistoriaDetran(Guid veiculoId)
        {
            var veiculo = veiculoRepository.GetById(veiculoId);

            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(detranOptions.BaseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var requestModel = new VistoriaModel()
            {
                Placa = veiculo.Placa,
                AgendadoPara = DateTime.Now.AddDays(detranOptions.QuantidadeDiasParaAgendamento)
            };
            var jsonContent = System.Text.Json.JsonSerializer.Serialize(requestModel);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await client.PostAsync(detranOptions.VistoriaUri, contentString);
        }
    }
}
