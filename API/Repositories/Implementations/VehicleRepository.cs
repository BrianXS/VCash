using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using API.Services.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public VehicleRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public VehicleResponse FindVehicleResponseById(int id)
        {
            var vehicle = _dbContext.Vehicles.Where(x => x.Id.Equals(id))
                .Include(x => x.Branch).FirstOrDefault();
            
            return _mapper.Map<VehicleResponse>(vehicle);
        }

        public Vehicle FindVehicleById(int id)
        {
            return _dbContext.Vehicles.Where(x => x.Id.Equals(id)).Include(x => x.Branch).FirstOrDefault();
        }

        public List<VehicleResponse> GetAllVehicles()
        {
            var vehicles = _dbContext.Vehicles
                .Include(x => x.Branch)
                .ToList();
            
            return _mapper.Map<List<VehicleResponse>>(vehicles);
        }

        public void CreateVehicle(VehicleCreateRequest vehicle)
        {
            _dbContext.Vehicles.Add(_mapper.Map<Vehicle>(vehicle));
            _dbContext.SaveChanges();
        }

        public VehicleResponse UpdateVehicle(int id, VehicleUpdateRequest updatedVehicle)
        {
            var vehicleToUpdate = _dbContext.Vehicles.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(updatedVehicle, vehicleToUpdate);

            _dbContext.Vehicles.Update(vehicleToUpdate);
            _dbContext.SaveChanges();

            return _mapper.Map<VehicleResponse>(vehicleToUpdate);
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            _dbContext.Vehicles.Remove(vehicle);
            _dbContext.SaveChanges();
        }
    }
}