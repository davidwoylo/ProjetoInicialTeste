using Domain.DTOs;
using Domain.Interfaces.Notificacoes;
using Domain.Interfaces.Services;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IHttpContextAccessor httpContextAccessor,
                                           IGerenciadorNotificacoes gerenciadorNotificacoes,
                                           IProdutoService produtoService) : base(gerenciadorNotificacoes, httpContextAccessor)
        {
            _produtoService = produtoService;
        }

        [HttpGet("buscaPorCodigoFornecedor")]
        public async Task<ProdutoDTO> ProdutoPorCodigoFornecedor(string codigoFornecedor)
        {
            return await _produtoService.BuscarProdutoPorCodigo(codigoFornecedor);
        }

        [HttpGet("listaProdutos")]
        public async Task<List<ProdutoDTO>> ListaProdutos(FiltroProdutoDTO filtro)
        {
            return await _produtoService.ListarProdutos(filtro);
        }

        [HttpPost("incluirProdutos")]
        public async Task<IActionResult> InserirProduto([FromBody] ProdutoViewModel produto)
        {
            if (!await _produtoService.Inserir(produto))
                return ResponseBadRequest();

            return new ObjectResult(new { code = StatusCodes.Status201Created, message = "Produto inserido com sucesso." });
        }

        [HttpPost("alterarProduto")]
        public async Task<IActionResult> AlterarProduto([FromBody] ProdutoDTO produto)
        {
            if (!await _produtoService.Alterar(produto))
                return ResponseBadRequest();

            return new ObjectResult(new { code = StatusCodes.Status200OK, message = "Produto alterado com sucesso." });
        }

        [HttpDelete("deletarProduto")]
        public async Task<IActionResult> DeletarProduto(int id)
        {
            if (!await _produtoService.Deletar(id))
                return ResponseBadRequest();

            return new ObjectResult(new { code = StatusCodes.Status200OK, message = "Produto excluído com sucesso." });
        }
    }
}
