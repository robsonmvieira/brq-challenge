using AutoMapper;
using Truck.Application.DTOS;

namespace Truck.Application.Mapper
{
    public class TruckMapper: Profile
    {
        public TruckMapper()
        {
            CreateMap<TruckApp.Domain.Entities.Truck, TruckDtoResponse>();
            CreateMap<TruckDtoRequest, TruckApp.Domain.Entities.Truck>();
        }
    }
}