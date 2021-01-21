using AutoMapper;
using StruckApp.API.ViewModels;
using Truck.Application.DTOS;

namespace StruckApp.API.AutoMapper
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<AddTruckRequest, TruckDtoRequest>();
            CreateMap<UpdateTruckRequest, TruckDtoRequest>();
        }
    }
}
