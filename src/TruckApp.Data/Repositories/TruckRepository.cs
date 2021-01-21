using TruckApp.Data.Data;
using TruckApp.Domain.Entities;
using TruckApp.Domain.Repositories;

namespace TruckApp.Data.Repositories
{
    public class TruckRepository: Repository<Truck>, ITruckRepository
    {
        public TruckRepository(TruckContext truckContext) : base(truckContext)
        {
        }
    }
}