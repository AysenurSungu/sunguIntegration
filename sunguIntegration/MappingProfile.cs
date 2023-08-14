using System;
using AutoMapper;
using sunguIntegration.DTO;
using sunguIntegration.DTO.RequestDTO;

namespace sunguIntegration
{
	public class MappingProfile : Profile 
	{
        public MappingProfile()
        {
            CreateMap<GeneralProductRequestDTO, TrendyolProductRequestDTO>()
                .ForMember(dest => dest.title, opt => opt.MapFrom(src => src.title))
                .ForMember(dest => dest.listPrice, opt => opt.MapFrom(src => src.price))
                .ForMember(dest => dest.salePrice, opt => opt.MapFrom(src => src.price))
                .ForPath(dest => dest.deliveryOption.deliveryDuration, opt => opt.MapFrom(src => src.trendyolFields.deliveryOption.deliveryDuration))
                .ForPath(dest => dest.deliveryOption.fastDeliveryType, opt => opt.MapFrom(src => src.trendyolFields.deliveryOption.fastDeliveryType))
                .ForPath(dest => dest.attributes, opt => opt.MapFrom(src => src.trendyolFields.attributes))
                .ForPath(dest => dest.images, opt => opt.MapFrom(src => src.trendyolFields.images));
        }
    }
}

