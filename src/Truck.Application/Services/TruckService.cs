using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Truck.Application.DTOS;
using Truck.Application.Services.interfaces;
using TruckApp.Core.DomainObject;
using TruckApp.Domain.Repositories;

namespace Truck.Application.Services
{
    public class TruckService: ITruckService
    {
        private readonly IMapper _mapper;
        private readonly ITruckRepository _truckRepository;

        public TruckService(ITruckRepository truckRepository, IMapper mapper)
        {
            _truckRepository = truckRepository;
            _mapper = mapper;
        }
        public async Task AddNewTruck(TruckDtoRequest request)
        {
            
            var truck = _mapper.Map<TruckApp.Domain.Entities.Truck>(request);
            truck.IsValid();
            await _truckRepository.Add(truck);
        }

        public async Task<IEnumerable<TruckDtoResponse>> ListTrucks()
        {
            var list = await _truckRepository.ListAll();
            return _mapper.Map<IList<TruckDtoResponse>>(list);
        }

        public async Task<TruckDtoResponse> GetTruckById(Guid id)
        {
            var source = await _truckRepository.GetById(id);

            if (source == null) throw new DomainException("Truck not found");

            var response = _mapper.Map<TruckDtoResponse>(source);
            return response;
        }

        public async Task UpdateTruck(Guid id, TruckDtoRequest request)
        {
            var truckExists = await _truckRepository.GetById(id);
            if (truckExists == null) throw new DomainException("Truck not found");
            truckExists.SetModel(request.Model);
            truckExists.SetYearModel(request.ModelYear);
            truckExists.IsValid();
            await _truckRepository.Update(truckExists);
            
        }

        public async Task RemoveTruck(Guid id)
        {
            await _truckRepository.Remove(id);
        }
    }
}