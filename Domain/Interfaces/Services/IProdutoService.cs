using Domain.DTOs;
using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IProdutoService : IService<Produto>
    {
        Task<ProdutoDTO> BuscarProdutoPorCodigo(string codigo);

        Task<List<ProdutoDTO>> ListarProdutos(FiltroProdutoDTO filtro);

        Task<bool> Inserir(ProdutoViewModel produto);

        Task<bool> Alterar(ProdutoDTO produto);

        Task<bool> Deletar(int id);
    }
}
