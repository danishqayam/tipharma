using AutoMapper;
using TiPharma.Models;
using TiPharma.EntityModel;

namespace TiPharma.CoreHelper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserMaster, UserMasterViewModel>();
            CreateMap<UserMasterViewModel, UserMaster>();
        }
    }
}