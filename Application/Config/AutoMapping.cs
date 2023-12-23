using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.ViewModels;

namespace Application.Config
{
    /// <summary>
    /// AutoMapper 
    /// </summary>
    public class AutoMapping : Profile
    {
        /// <summary>
        /// Criação do mapeamento de entidades e dto`s
        /// </summary>
        public AutoMapping()
        {
            //Mapper Entidade <-> DataTransferObject            
            CreateMap<Produto, ProdutoDTO>().ReverseMap();

            //Mapper Entidade <-> ViewModel
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();

            //Mapper DataTransferObject <-> ViewModel

        }
    }
}
