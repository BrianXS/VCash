using System;
using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using API.Services.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class DrawerRepository : IDrawerRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public DrawerRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public List<DrawerResponse> GetAllDrawers()
        {
            var drawers = _dbContext.Drawers
                .Include(x => x.DrawerRange)
                .Include(x => x.DenominationType)
                .ToList();
            
            return _mapper.Map<List<DrawerResponse>>(drawers);
        }

        public DrawerResponse FindDrawerResourceById(int id)
        {
            var drawer = _dbContext.Drawers
                .Where(x => x.Id.Equals(id))
                .Include(x => x.DrawerRange)
                .Include(x => x.DenominationType)
                .FirstOrDefault();
            
            return _mapper
                .Map<DrawerResponse>(drawer);
        }

        public Drawer FindDrawerById(int id)
        {
            return _dbContext.Drawers
                .Include(x => x.DrawerRange)
                .Include(x => x.DenominationType)
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public void CreateDrawer(DrawerRequest drawer)
        {
            _dbContext.Drawers.Add(_mapper.Map<Drawer>(drawer));
            _dbContext.SaveChanges();
        }

        public DrawerResponse UpdateDrawer(int id, DrawerRequest drawer)
        {
            var drawerToChange = _dbContext.Drawers.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(drawer, drawerToChange);
            
            _dbContext.Drawers.Update(drawerToChange);
            _dbContext.SaveChanges();
            return _mapper.Map<DrawerResponse>(drawerToChange);
        }

        public void DeleteDrawer(Drawer drawer)
        {
            _dbContext.Drawers.Remove(drawer);
            _dbContext.SaveChanges();
        }
    }
}