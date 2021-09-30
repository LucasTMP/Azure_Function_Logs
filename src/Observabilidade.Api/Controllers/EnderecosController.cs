using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Observabilidade.Api.Extensions;
using Observabilidade.Api.Interfaces;
using Observabilidade.Api.Models.Enums;
using Observabilidade.Api.Services;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Observabilidade.Api.Controllers
{
    [Route("api/v1/enderecos")]
    public class EnderecosController : MainController
    {
        private readonly LogService _logger;
        private readonly ApiCepWebService _apiCepWebService;

        public EnderecosController(LogService logger,
                                   INotificador notificador,
                                   ApiCepWebService apiCepWebService) : base(notificador)
        {
            _logger = logger;
            _apiCepWebService = apiCepWebService;
        }

        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        [CustomResponse(StatusCodes.Status500InternalServerError)]
        [HttpGet("cep/{cep}")]
        public async Task<IActionResult> ObterEndereco(string cep)
        {
            await _logger.EnviarLog($"Requisição GET para o endpoint {nameof(ObterEndereco)} com os dados: {cep}", TipoLog.Information);

            if (!Regex.IsMatch(cep, "^[0-9]{8}$"))
            {
                await _logger.EnviarLog($"Falha na requisição GET, statuscode 400, para o endpoint {nameof(ObterEndereco)} com os dados: {cep}", TipoLog.Error);
                return ResponseBadRequest("Forneça um numero de CEP válido: EX 66615860 [Sem o traço (-)]");
            }

            var endereco = await _apiCepWebService.BuscarEnderecoPeloCep(cep);
            if (endereco == null) return ResponseInternalServerError("Oooops! Algo aconteceu de errado, por favor, tente mais tarde.");
            if (endereco.Erro) return ResponseNotFound("Não foi possivel encontrar um endereco para o CEP fornecido.");

            await _logger.EnviarLog($"Sucesso na requisição GET, statuscode 200, para o endpoint {nameof(ObterEndereco)} com os dados: {cep}", TipoLog.Information);

            return ResponseOk(endereco);
        }
    }
}