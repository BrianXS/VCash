using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using API.Entities;
using API.Entities.AtmMaintenance;
using API.Enums.ATM;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Incoming.AtmMaintenanceResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using API.Resources.Outgoing.AtmMaintenanceResources;
using API.Services.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class AtmModuleRepository : IAtmModuleRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public AtmModuleRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AtmModuleResponse FindAtmModuleResponseById(int id)
        {
            return _mapper.Map<AtmModuleResponse>(_dbContext.AtmModules.FirstOrDefault(x => x.Id == id));
        }

        public AtmModule FindAtmModuleById(int id)
        {
            return _dbContext.AtmModules.FirstOrDefault(x => x.Id == id);
        }

        public AtmModule FindAtmModuleByDescriptionAndPlatform(string name, Brand platform)
        {
            return _dbContext.AtmModules.FirstOrDefault(x => x.Description == name && x.Platform == platform);
        }

        public List<AtmModuleResponse> GetAllAtmModules()
        {
            return _mapper.Map<List<AtmModuleResponse>>(_dbContext.AtmModules.ToList());
        }

        public void CreateAtmModule(AtmModuleRequest atmModule)
        {
            _dbContext.AtmModules.Add(_mapper.Map<AtmModule>(atmModule));
            _dbContext.SaveChanges();
        }

        public void CreateAtmModulesRange(List<AtmModuleRequest> atmModules)
        {
            _dbContext.AtmModules.AddRange(_mapper.Map<List<AtmModule>>(atmModules));
            _dbContext.SaveChanges();
        }

        public AtmModuleResponse UpdateAtmModule(int id, AtmModuleRequest updatedAtmModule)
        {
            var moduleToChange = _dbContext.AtmModules.FirstOrDefault(x => x.Id == id);
            _mapper.Map(moduleToChange, updatedAtmModule);

            _dbContext.AtmModules.Update(moduleToChange);
            _dbContext.SaveChanges();
            
            return _mapper.Map<AtmModuleResponse>(moduleToChange);
        }

        public void DeleteAtmModule(AtmModule atmModule)
        {
            _dbContext.AtmModules.Remove(atmModule);
            _dbContext.SaveChanges();
        }

        public int Count()
        {
            return _dbContext.AtmModules.Count();
        }
    }
}