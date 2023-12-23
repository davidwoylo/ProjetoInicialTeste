using Domain.Interfaces.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Notificacoes
{
    /// <summary>
    /// Classe de Gerenciador de Notificações
    /// </summary>
    public class GerenciadorNotificacoes : IGerenciadorNotificacoes
    {
        private IList<Notificacao> _notificacoes;
        public bool IsNotFound { get; set; }
        public GerenciadorNotificacoes()
        {
            _notificacoes = new List<Notificacao>();
        }

        /// <summary>
        /// Adicionar a notificação
        /// </summary>
        /// <param name="notificacao"></param>
        /// <returns></returns>
        public virtual Task Notificar(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
            return Task.CompletedTask;
        }
        public virtual IList<Notificacao> Notificacoes() => _notificacoes;

        /// <summary>
        /// Verificar se tem notificação
        /// </summary>
        /// <returns></returns>
        public virtual bool TemNotificacoes() => Notificacoes().Any();

        public void Dispose()
        {
            _notificacoes = new List<Notificacao>();
        }
    }
}
