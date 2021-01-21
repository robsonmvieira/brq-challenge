using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StruckApp.API.ViewModels;
using Truck.Application.DTOS;
using Truck.Application.Services.interfaces;

namespace StruckApp.API.Controllers
{
    [Route("api/truckController")]
    public class TruckController: MainController
    {
        private readonly ITruckService _truckService;
        private readonly IMapper _mapper;

        public TruckController(ITruckService truckService, IMapper mapper)
        {
            _truckService = truckService;
            _mapper = mapper;
        }
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ListAllTruck()
        {
            return CustomResponse(await _truckService.ListTrucks());
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddTruck(AddTruckRequest request)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var source = _mapper.Map<TruckDtoRequest>(request);
            await _truckService.AddNewTruck(source);
            return CustomResponse();
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(Guid id, UpdateTruckRequest request)
        {
            var source = _mapper.Map<TruckDtoRequest>(request);
            await _truckService.UpdateTruck(id, source);
            return CustomResponse();
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(Guid id)
        {
            return CustomResponse(await _truckService.GetTruckById(id));
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> RemoveTruck(Guid id)
        {
            await _truckService.RemoveTruck(id);
            return CustomResponse();
        }
        
        

        
        
    }
}