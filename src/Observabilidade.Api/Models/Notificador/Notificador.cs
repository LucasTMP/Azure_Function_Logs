using Observabilidade.Api.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Observabilidade.Api.Models.Notificador
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes { get; set; }

        public Notificador()
        {
            _notificacoes = new();
        }

        public void AdicionarNotificacao(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ListaNoticacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}