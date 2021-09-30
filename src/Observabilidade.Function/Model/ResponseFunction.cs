using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;
using System.Net;

namespace Observabilidade.Function.Model
{
    public static class ResponseFunction
    {
        public static HttpResponseData GerarResposta(HttpRequestData req, object data, HttpStatusCode status)
        {
            var response = req.CreateResponse(status);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");
            var resposta = JsonConvert.SerializeObject(data);
            response.WriteString(resposta);
            return response;
        }
    }
}
