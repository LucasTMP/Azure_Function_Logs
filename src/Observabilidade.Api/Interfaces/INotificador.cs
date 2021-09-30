using Observabilidade.Api.Models.Notificador;
using System.Collections.Generic;

namespace Observabilidade.Api.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();

        List<Notificacao> ListaNoticacoes();

        void AdicionarNotificacao(Notificacao notificacao);
    }
}