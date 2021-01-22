using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Truck.Application.DTOS;
using Truck.Application.Services;
using Truck.Application.Services.interfaces;
using TruckApp.Core.DomainObject;
using TruckApp.Domain.Repositories;
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
        
        [Fact(DisplayName = "CreateNewTruck should be able to create new truck if valid data is provided")]
        [Trait("Service", "TruckService")]
        public void TruckService_CreateNewTruck_ShouldCreateNewTruckIfValidDataIsProvided()
        {
            // arrange
            Mock<ITruckRepository> truckRepositoryFake = new Mock<ITruckRepository>();
            Mock<IMapper> mapperFake = new Mock<IMapper>();

            var mockTruckService = new TruckService(truckRepositoryFake.Object, mapperFake.Object);
            
            // var mock = mockTruckService.Object;
            var truck = new Domain.Entities.Truck("FM", 2021);
            var truckDto = new TruckDtoRequest()
            {
                Model = "FH",
                ModelYear = 2022,
                
            };
            
            // act
            mapperFake.Setup(m => m.Map<Domain.Entities.Truck>(It.IsAny<TruckDtoRequest>())).Returns(truck);
            truckRepositoryFake.Setup(m => m.Add(truck)).ReturnsAsync(() => true);
            
            
            // assert
            var response = mockTruckService.AddNewTruck(truckDto);
          

            truckRepositoryFake.Verify(x => x.Add(truck), Times.Once);
            Assert.True(response.Result);
        }
        
        [Fact(DisplayName = "CreateNewTruck should throw if valid data is provided")]
        [Trait("Service", "TruckService")]
        public void TruckService_CreateNewTruck_ShouldThrowWhenInvalidDataIsProvided()
        {
            // arrange
            Mock<ITruckRepository> truckRepositoryFake = new Mock<ITruckRepository>();
            Mock<IMapper> mapperFake = new Mock<IMapper>();

            var mockTruckService = new TruckService(truckRepositoryFake.Object, mapperFake.Object);
            
            // var mock = mockTruckService.Object;
            var truck = new Domain.Entities.Truck("FM", 2021);
            var truckDto = new TruckDtoRequest()
            {
                Model = "FH",
                
            };
            
            // act
            mapperFake.Setup(m => m.Map<Domain.Entities.Truck>(It.IsAny<TruckDtoRequest>())).Returns(truck);
            truckRepositoryFake.Setup(m => m.Add(truck)).ReturnsAsync(() => false);
            
            
            // assert
            var response = mockTruckService.AddNewTruck(truckDto);
          

            truckRepositoryFake.Verify(x => x.Add(truck), Times.Once);
            Assert.False(response.Result);
        }
        
        [Fact(DisplayName = "ListAll should return a list of truck")]
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
                ModelYear = 2021
            };

            var list = new List<TruckDtoResponse>() {truck};
            
            // act
            mockTruckService.Setup<Task<IEnumerable<TruckDtoResponse>>>(m => m.ListTrucks())
                .Returns(() => Task.FromResult<IEnumerable<TruckDtoResponse>>(list));

            var result =  mock.ListTrucks();
            // assert
            var size = result.Result.Count();

            Assert.Equal(1, size);
        }
        
        [Fact(DisplayName = "GetTruckById should return if truck is found")]
        [Trait("Service", "TruckService")]
        public void TruckService_GetTruckById_ShouldTruck()
        {
            // arrange
            Mock<ITruckService> mockTruckService = new Mock<ITruckService>();
            
            var mock = mockTruckService.Object;
            Guid id = Guid.NewGuid();
            var truck = new TruckDtoResponse
            {
                Id = id,
                Model = "FH",
                YearManufacture = 2021,
                ModelYear = 2021
            };
            
            // act
            mockTruckService.Setup<Task<TruckDtoResponse>>(m => m.GetTruckById(id))
                .Returns(() => Task.FromResult<TruckDtoResponse>(truck));

            var result =  mock.GetTruckById(id);
            // assert
            var response = result.Result;

            Assert.Equal(id, response.Id);
        }
        
        [Fact(DisplayName = "GetTruckById should return if truck is found")]
        [Trait("Service", "TruckService")]
        public void TruckService_GetTruckById_ShouldThrowWhenTruckNotFound()
        {
            // arrange
            Mock<ITruckService> mockTruckService = new Mock<ITruckService>();
            
            var mock = mockTruckService.Object;
            Guid id = Guid.NewGuid();
        
            // act
            mockTruckService.Setup<Task<TruckDtoResponse>>(m => m.GetTruckById(id))
                .Returns(() => null);
            
            // assert
            Assert.ThrowsAsync<DomainException>(() =>  mock.GetTruckById(id));
        }
        
       
        
        
    }
}