using System;

namespace Truck.Application.DTOS
{
    public class TruckDtoResponse
    {
        public Guid Id { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get;  set; }
    }
}