using Data.Context;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly TesteContext context;
        public ProdutoRepository(TesteContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<List<Produto>> ListarProdutos(FiltroProdutoDTO filtro)
        {
            var result = new List<Produto>();
            result = await DbSet.ToListAsync();

            if (filtro.Situacao != null) 
            {
                result = result.Where(x => x.Situacao == filtro.Situacao).ToList();
            }
            if (!string.IsNullOrEmpty(filtro.CodigoFornecedor)) 
            {
                result = result.Where(x => x.CodigoFornecedor == filtro.CodigoFornecedor).ToList();
            }
            if (!string.IsNullOrEmpty(filtro.CnpjFornecedor)) 
            {
                result = result.Where(x => x.CnpjFornecedor == Extension.RemoveMascara(filtro.CnpjFornecedor)).ToList();
            }
            return result.Take(filtro.QtdPagina.Value).ToList();
        }

        public async Task<Produto> BuscaProdutoPorCodigo(string codigo)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.CodigoFornecedor == codigo);
        }

        public async Task<Produto> BuscaProdutoPorId(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
