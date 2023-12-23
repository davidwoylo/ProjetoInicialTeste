using Domain.Interfaces.Notificacoes;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace Application.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    /// 
    [Authorize]
    public abstract class BaseController : Controller
    {
        private readonly IGerenciadorNotificacoes gerenciadorNotificacoes;
        private readonly ISession session;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="_gerenciadorNotificacoes"></param>
        public BaseController(IGerenciadorNotificacoes _gerenciadorNotificacoes,
            IHttpContextAccessor httpContextAccessor)
        {
            session = httpContextAccessor.HttpContext.Session;
            gerenciadorNotificacoes = _gerenciadorNotificacoes;
        }
        /// <summary>
        /// Verifica se tem notificação
        /// </summary>
        /// <returns></returns>
        internal bool IsOperacaoValida()
        {
            return !gerenciadorNotificacoes.TemNotificacoes();
        }

        
        /// <summary>
        /// Response para NotFound
        /// </summary>
        /// <returns></returns>
        internal IActionResult ResponseNotFound()
        {
            return NotFound(gerenciadorNotificacoes.Notificacoes().GroupBy(x => x.Chave).ToDictionary(k => k.Key, v => v.Select(s => s.Valor)));
        }

        /// <summary>
        /// Response para BadRequest
        /// </summary>
        /// <returns></returns>
        internal IActionResult ResponseBadRequest()
        {
            return new BadRequestObjectResult(new
            {
                code = StatusCodes.Status400BadRequest,
                error =
                    gerenciadorNotificacoes
                    .Notificacoes()
                    .GroupBy(x => x.Chave)
                    .ToDictionary(k => k.Key, v => v.Select(s => s.Valor))
            }
            );
        }
    }
}
