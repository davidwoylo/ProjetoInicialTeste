using Domain.Interfaces.Notificacoes;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Notificacoes
{
    /// <summary>
    /// Notificar
    /// </summary>
    public abstract class Notificable
    {
        private readonly IGerenciadorNotificacoes gerenciadorNotificacoes;
        public Notificable(IGerenciadorNotificacoes _gerenciadorNotificacoes)
        {
            gerenciadorNotificacoes = _gerenciadorNotificacoes;
        }

        /// <summary>
        /// Notificar
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual Task Notificar(string key, string value)
        {
            return gerenciadorNotificacoes.Notificar(new Notificacao(key, value));
        }

        /// <summary>
        /// notificar lista de erros
        /// </summary>
        /// <param name="validationResult"></param>
        /// <returns></returns>
        protected virtual async Task NotificarErrosValidacao(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                await Notificar(error.PropertyName, error.ErrorMessage);
            }
        }

        protected virtual bool IsValid()
        {
            return !gerenciadorNotificacoes.TemNotificacoes();
        }
    }
}
