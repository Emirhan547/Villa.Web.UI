using AutoMapper;
using Villa.Dto.Dtos.BannerDtos;
using Villa.Entity.Entities;

namespace Villa.Web.UI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<ResultBannerDto,Banner>().ReverseMap();
            CreateMap<UpdateBannerDto,Banner>().ReverseMap();
            CreateMap<CreateBannerDto,Banner>().ReverseMap();
        }
    }
}
