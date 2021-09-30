using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Observabilidade.Api.Models;
using Observabilidade.Api.Models.Enums;
using Observabilidade.Api.Utils.WebResponses;
using System.Net.Http;
using System.Threading.Tasks;

namespace Observabilidade.Api.Services
{
    public class ApiCepWebService
    {
        private readonly LogService _logger;
        private readonly string _url;

        public ApiCepWebService(LogService logger, IOptions<ConnectionStrings> urls)
        {
            _logger = logger;
            _url = urls.Value.ViaCepApi;
        }

        public async Task<ApiCepIntegrationWebResponse> BuscarEnderecoPeloCep(string cep)
        {
            HttpClient httpClient = new();
            var url = $"{_url}/ws/{cep}/json/";
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                await _logger.EnviarLog($"Falha na chamada para a API externa de CEP, statuscode 400, com os dados: {cep}", TipoLog.Error);
                return null;
            }

            var reponseString = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonConvert.DeserializeObject<ApiCepIntegrationWebResponse>(reponseString);

            if (jsonResponse.Erro)
            {
                await _logger.EnviarLog($"Falha na chamada para a API externa de CEP, statuscode 404, com os dados: {cep}", TipoLog.Warning);
            }

            return jsonResponse;
        }
    }
}