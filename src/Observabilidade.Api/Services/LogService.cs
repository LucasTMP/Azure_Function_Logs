using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Observabilidade.Api.Models;
using Observabilidade.Api.Models.Enums;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Observabilidade.Api.Services
{
    public class LogService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _url;

        public LogService(IHttpContextAccessor httpContextAccessor, IOptions<ConnectionStrings> urls)
        {
            _httpContextAccessor = httpContextAccessor;
            _url = urls.Value.AzureFunctionLog;
        }

        public async Task<bool> EnviarLog(string mensagem,
                                          TipoLog tipoLog,
                                          [CallerMemberName] string metodoChamado = "",
                                          [CallerLineNumber] int linhaChamada = 0,
                                          [CallerFilePath] string arquivoChamado = "")
        {
            var log = GerarLog(mensagem, tipoLog, metodoChamado, linhaChamada, arquivoChamado);
            HttpClient httpClient = new();
            try
            {
                var response = await httpClient.PostAsync(_url, new StringContent(JsonConvert.SerializeObject(log),
                                                                             Encoding.UTF8, "application/json"));
                return !response.IsSuccessStatusCode;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        private Log GerarLog(string mensagem, TipoLog tipoLog, string metodoChamado, int linhaChamada, string arquivoChamado)
        {
            var dadosRequest = _httpContextAccessor.HttpContext.Request;

            var enderecoEndpoint = dadosRequest.Path.ToString();
            var host = dadosRequest.Host.ToString();
            var metodoHttp = dadosRequest.Method.ToString();
            var tipoProcotoloTransporte = dadosRequest.Scheme.ToString();

            var detalhesChamada = $"Log gerado no arquivo {arquivoChamado.Split('\\').Last()} " +
                           $"pelo metodo {metodoChamado}() " +
                           $"na linha de numero {linhaChamada};";

            var detalhesRequest = $"Host alvo da requisição {host} " +
                           $"para o endpoint {enderecoEndpoint} " +
                           $"usando o metodo HTTP {metodoHttp} " +
                           $"com o protocolo de transporte {tipoProcotoloTransporte};";

            var detalhes = detalhesChamada + detalhesRequest;
            mensagem = $"[{tipoLog}] {mensagem}";

            var log = new Log(mensagem, detalhes);
            return log;
        }
    }
}