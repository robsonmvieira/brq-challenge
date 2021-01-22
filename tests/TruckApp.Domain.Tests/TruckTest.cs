using TruckApp.Core.DomainObject;
using TruckApp.Domain.Entities;
using Xunit;

namespace TruckApp.Domain.Tests
{
    public class TruckTest
    {
        [Fact(DisplayName = "validate Truck is valid method")]
        [Trait("Truck", "Truck is Valid")]
        public void Truck_IsValid_ShouldReturnValidInstance()
        {
            // Arrange
            var truck = new Truck("FM", 2021, 2021);
            
            // Act
            var result = truck.IsValid();
            
            // assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "validate Truck is valid method")]
        [Trait("Truck", "Truck is Invalid")]
        public void Truck_IsValid_ShouldBeReturnInvalidInstance()
        {
            // Arrange
            var truck = new Truck("FM", 2019, 2019);
            
            // Act
            var result = truck.IsValid();
            
            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(2,result.Errors.Count);
        }

        [Fact(DisplayName = "SetModel should be set with valid option")]
        [Trait("Truck ", "Truck Model is Valid")]
        public void Truck_SetMode_ShouldSetValidOptionToModelProperty()
        {
            // Arrange
            var truck = new Truck("FM", 2021, 2021);
            
            // act
            truck.SetModel("FH");
            
            // assert
            Assert.Equal("FH", truck.Model);
        }
        
        [Fact(DisplayName = "SetModel should throw if set valid value")]
        [Trait("Truck ", "Truck Model is invalid")]
        public void Truck_SetModel_ShouldThrowWhenInValidOptionSetModelProperty()
        {
            // Arrange
            var truck = new Truck("FH", 2021, 2019);
            
            // act and assert
            Assert.Throws<DomainException>(() => truck.SetModel("invalidName"));
        }

        [Fact(DisplayName = "SetYearModel should be set with valid option")]
        [Trait("Truck ", "Truck Model is Valid")]
        public void Truck_SetYearModel_ShouldSetValidOptionToYearModelProperty()
        {
            // Arrange
            var truck = new Truck("FH", 2022, 2022);
            
            // Act
            truck.SetYearModel(2023);
            
            // Assert
            Assert.Equal(2023, truck.ModelYear);
        }
        
        [Fact(DisplayName = "SetYearModel should throw when invalid data to year model is provided")]
        [Trait("Truck ", "Truck Model is Valid")]
        public void Truck_SetYearModel_ShouldThrowWhenAInvalidDataIsProvidedToYearModelProperty()
        {
            // Arrange
            var truck = new Truck("FH", 2022, 2022);

            // act and Assert
            Assert.Throws<DomainException>(() => truck.SetYearModel(2019));
        }
        
    }
}