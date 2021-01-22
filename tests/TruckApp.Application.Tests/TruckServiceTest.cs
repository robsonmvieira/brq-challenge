using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Truck.Application.DTOS;
using Truck.Application.Services;
using Truck.Application.Services.interfaces;
using Xunit;
using Truck = TruckApp.Domain.Entities.Truck;

namespace TruckApp.Application.Tests
{
    public class TruckServiceTest
    {
        /*
         * Task AddNewTruck(TruckDtoRequest request);
        Task<IEnumerable<TruckDtoResponse>> ListTrucks();
        Task<TruckDtoResponse> GetTruckById(Guid id);
        Task UpdateTruck(Guid id,TruckDtoRequest request);
        Task RemoveTruck(Guid id);
         */
        [Fact(DisplayName = "ListAll should be return a list of truck")]
        [Trait("Service", "TruckService")]
        public void TruckService_ListTrucks_ShouldReturnsTruckList()
        {
            // arrange
            Mock<ITruckService> mockTruckService = new Mock<ITruckService>();
            
            var mock = mockTruckService.Object;
            
            var truck = new TruckDtoResponse
            {
                Model = "FH",
                YearManufacture = 2021,
                YearModel = 2021
            };

            var list = new List<TruckDtoResponse>() {truck};
            
            // act
            mockTruckService.Setup<Task<IEnumerable<TruckDtoResponse>>>(m => m.ListTrucks())
                .Returns(() => Task.FromResult<IEnumerable<TruckDtoResponse>>(list));

            var result =  mock.ListTrucks();
            // assert

            // Assert.Equal(1, );


        }
    }
}