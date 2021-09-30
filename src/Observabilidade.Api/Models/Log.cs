using System.Reflection;

namespace Observabilidade.Api.Models
{
    public class Log
    {
        public Log(string mensagem, string detalhe)
        {
            NomeAplicacao = Assembly.GetEntryAssembly().GetName().Name;
            Mensagem = mensagem;
            Detalhe = detalhe;
        }

        public string NomeAplicacao { get; private set; }
        public string Mensagem { get; private set; }
        public string Detalhe { get; private set; }
    }
}