using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StruckApp.API.ViewModels;
using Truck.Application.Services.interfaces;

namespace StruckApp.API.Controllers
{
    [Route("api/[apiController]")]
    public class TruckController: MainController
    {
        private ITruckService _truckService;

        public TruckController(ITruckService truckService)
        {
            _truckService = truckService;
        }
        [HttpGet("")]
        public async Task<ActionResult> ListAllTruck()
        {
            return CustomResponse(await _truckService.ListTrucks());
        }
        
        
    }
}