using System;

namespace Truck.Application.DTOS
{
    public class TruckDtoResponse
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public int YearModel { get; set; }
        public int YearManufacture { get; set; }
    }
}