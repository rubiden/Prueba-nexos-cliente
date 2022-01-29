using Model = Nexos.Cliente.Domain.Core.Models;
using BM = Nexos.Cliente.Core.API.BindingModel;
using AutoMapper;

namespace Nexos.Cliente.Core.API.Mapping
{
    /// <summary>
    /// Provide a profile for mapping
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Create mappings
        /// </summary>
        public MappingProfile()
        {
            CreateMap<BM.AutorDTO, Model.Autor>().ReverseMap();
        }
    }
}
