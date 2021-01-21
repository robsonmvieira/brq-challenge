using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Truck.Application.DTOS;

namespace Truck.Application.Services.interfaces
{
    public interface ITruckService
    {
        Task AddNewTruck(TruckDtoRequest request);
        Task<IEnumerable<TruckDtoResponse>> ListTrucks();

        Task<TruckDtoResponse> GetTruckById(Guid guid);

        Task UpdateTruck(TruckDtoRequest request);

        Task RemoveTruck(Guid id);
    }
}