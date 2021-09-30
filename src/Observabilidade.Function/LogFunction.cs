using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Observabilidade.Function.Model;
using Observabilidade.Function.Services.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Observabilidade.Function
{
    public class LogFunction
    {
        private readonly ILogService _service;
        private readonly ILogger _logger;

        public LogFunction(ILogger<LogFunction> logger, ILogService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("Log")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req, FunctionContext executionContext)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var log = JsonConvert.DeserializeObject<Log>(requestBody);

            if (log == null) return ResponseFunction.GerarResposta(req, new { Erro = new[]{ "Por favor, forneça um objeto válido" }.ToList() }, HttpStatusCode.BadRequest);
            

                if (log.IsInvalid())
            {
                _logger.LogError($"Erro de validação: {requestBody}");
                return ResponseFunction.GerarResposta(req, new { Erro = log.FalhasValidacao }, HttpStatusCode.BadRequest);
            }

            _logger.LogInformation($"Log recebido: {requestBody}");

            try
            {
                await _service.AddLog(log);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Falha na tentativa de inserção: {ex.Message}");
                return ResponseFunction.GerarResposta(req, new { Erro = ex.Message }, HttpStatusCode.InternalServerError);
            }

            return ResponseFunction.GerarResposta(req, log, HttpStatusCode.OK);
        }
    }
}
