using Domain.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Notificacoes
{
    public interface IGerenciadorNotificacoes
    {
        Task Notificar(Notificacao notificacao);
        IList<Notificacao> Notificacoes();
        bool TemNotificacoes();
    }
}
