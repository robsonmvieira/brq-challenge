using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Truck.Application.DTOS;

namespace Truck.Application.Services.interfaces
{
    public interface ITruckService
    {
        Task<bool> AddNewTruck(TruckDtoRequest request);
        Task<IEnumerable<TruckDtoResponse>> ListTrucks();

        Task<TruckDtoResponse> GetTruckById(Guid id);

        Task UpdateTruck(Guid id,TruckDtoRequest request);

        Task RemoveTruck(Guid id);
    }
}