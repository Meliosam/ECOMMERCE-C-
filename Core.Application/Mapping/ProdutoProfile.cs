using AutoMapper;
using Core.Domain.Entities;
using Core.Application.CasosUso;

namespace Core.Application.Mapping
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            // Mapeamento bidirecional entre Produto e ProdutoDTO
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}