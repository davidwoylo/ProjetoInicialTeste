using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<List<Produto>> ListarProdutos(FiltroProdutoDTO filtro);

        Task<Produto> BuscaProdutoPorCodigo(string codigo);

        Task<Produto> BuscaProdutoPorId(int id);
    }
}
