using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Notificacoes;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProdutoService : BaseService<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository,
                                     IGerenciadorNotificacoes _gerenciadorNotificacoes,
                                     IMapper mapper) : base(produtoRepository, _gerenciadorNotificacoes, mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> BuscarProdutoPorCodigo(string codigo)
        {
            var result = _mapper.Map<ProdutoDTO>(await _produtoRepository.BuscaProdutoPorCodigo(codigo));

            return result;

        }

        public async Task<List<ProdutoDTO>> ListarProdutos(FiltroProdutoDTO filtro)
        {
            var result = _mapper.Map<List<ProdutoDTO>>(await _produtoRepository.ListarProdutos(filtro));

            return result;

        }

        public async Task<bool> Inserir(ProdutoViewModel produto)
        {
            try
            {
                if (produto.DataFabricacao.Date >= produto.DataValidade.Date) 
                {
                    await Notificar("error", $"Erro, Data de validade tem que ser maior que data de fabricação.");
                    return false;
                }
                if (!Extension.IsCnpj(produto.CnpjFornecedor))
                {
                    await Notificar("error", $"Erro, CNPJ inválido.");
                    return false;
                }
                if (await _produtoRepository.BuscaProdutoPorCodigo(produto.CodigoFornecedor) != null) 
                {
                    await Notificar("error", $"Erro, Código do fornecedor já existe na base de dados.");
                    return false;
                }

                produto.CnpjFornecedor = Extension.RemoveMascara(produto.CnpjFornecedor);
                await PostAsync(mapper.Map<Produto>(produto));
                return true;
            }
            catch (Exception ex)
            {
                await Notificar("error", $"Erro, tente novamente mais tarde. {ex.Message}");
                return false;
            }

        }

        public async Task<bool> Alterar(ProdutoDTO produto)
        {
            try
            {
                var resultProduto = Get(produto.Id);
                if (resultProduto == null) 
                {
                    await Notificar("error", $"Erro, Favor informar um Id que exista na base de dados.");
                    return false;
                }
                if (produto.DataFabricacao.Date >= produto.DataValidade.Date)
                {
                    await Notificar("error", $"Erro, Data de validade tem que ser maior que data de fabricação.");
                    return false;
                }
                if (!Extension.IsCnpj(produto.CnpjFornecedor))
                {
                    await Notificar("error", $"Erro, CNPJ inválido.");
                    return false;
                }
                
                resultProduto.Situacao = produto.Situacao;
                resultProduto.DescricaoProduto = produto.DescricaoProduto;
                resultProduto.DataFabricacao = produto.DataFabricacao;
                resultProduto.DataValidade = produto.DataValidade;
                resultProduto.CodigoFornecedor = produto.CodigoFornecedor;
                resultProduto.DescricaoFornecedor = produto.DescricaoFornecedor;
                resultProduto.CnpjFornecedor = Extension.RemoveMascara(produto.CnpjFornecedor);
                await PutAsync(resultProduto);
                return true;
            }
            catch(Exception ex)
            {
                await Notificar("error", $"Erro, {ex.Message}.");
                return false;
            }
        }

        public async Task<bool> Deletar(int id)
        {
            try
            {
                var resultProduto = Get(id);
                if (resultProduto == null)
                {
                    await Notificar("error", $"Erro, Favor informar um Id que exista na base de dados.");
                    return false;
                }
                resultProduto.Situacao = false;

                await PutAsync(mapper.Map<Produto>(resultProduto));
                return true;
            }
            catch (Exception ex)
            {
                await Notificar("error", $"Erro, {ex.Message}.");
                return false;
            }
        }
    }
}
