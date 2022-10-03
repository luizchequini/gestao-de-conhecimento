using AutoMapper;
using BaseDeConhecimento.Application.DTOS;
using BaseDeConhecimento.Application.DTOS.Request;
using BaseDeConhecimento.Domain.Entidades;

namespace BaseDeConhecimento.Application.AutoMapper
{
    public class MappingProfiles :Profile
    {

        public MappingProfiles()
        {

            CreateMap<Conhecimento, ConhecimentoDTO>().ReverseMap();
            CreateMap<ConhecimentoDTO, Conhecimento>().ReverseMap();
            CreateMap<Conhecimento, CreateConhecimentoRequestDTO>().ReverseMap();
            
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<CreateCategoriaRequestDTO, CategoriaDTO>().ReverseMap();
            CreateMap<CreateCategoriaRequestDTO, Categoria>().ReverseMap();
        
             
        }


    }
}
