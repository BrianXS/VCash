using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;

namespace API.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        VehicleResponse FindVehicleResponseById(int id);
        Vehicle FindVehicleById(int id);
        List<VehicleResponse> GetAllVehicles();
        void CreateVehicle(VehicleCreateRequest vehicle);
        VehicleResponse UpdateVehicle(int id, VehicleUpdateRequest vehicle);
        void DeleteVehicle(Vehicle vehicle);
    }
}