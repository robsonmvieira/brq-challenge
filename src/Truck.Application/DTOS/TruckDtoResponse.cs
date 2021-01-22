using System;

namespace Truck.Application.DTOS
{
    public class TruckDtoResponse
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int YearManufacture { get; set; }
    }
}