using AutoMapper;
using Truck.Application.DTOS;

namespace Truck.Application.Mapper
{
    public class TruckMapper: Profile
    {
        public TruckMapper()
        {
            CreateMap<TruckApp.Domain.Entities.Truck, TruckDtoResponse>()
                .ForMember(dst => dst.Id,
                    x
                        => x.MapFrom(d => d.Id))
                .ForMember(dst => dst.Model, x =>
                    x.MapFrom(d => d.Model))
                .ForMember(dst => dst.ModelYear, x =>
                    x.MapFrom(d => d.ModelYear))
                .ForMember(dst => dst.YearManufacture, x =>
                    x.MapFrom(d => d.YearManufacture));
            
            CreateMap<TruckDtoRequest, TruckApp.Domain.Entities.Truck>()
                .ForMember(x => x.Model,
                    from => from.MapFrom(x => x.Model))
                .ForMember(x => x.ModelYear, from =>
                    from.MapFrom(x => x.ModelYear))
                .ForMember(dst => dst.YearManufacture, opt => opt.Ignore());

            CreateMap<TruckApp.Domain.Entities.Truck, TruckDtoRequest>()
                .ForMember(x => x.Model,
                    from => from.MapFrom(x => x.Model))
                .ForMember(x => x.ModelYear, from =>
                    from.MapFrom(x => x.ModelYear));
        }
    }
}
