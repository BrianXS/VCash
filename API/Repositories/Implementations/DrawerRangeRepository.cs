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
    public class DrawerRangeRepository : IDrawerRangeRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public DrawerRangeRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public List<DrawerRangeResponse> GetAllDrawerRanges()
        {
            var drawers = _dbContext.DrawerRanges
                .Include(x => x.Customer)
                .ToList();
            
            return _mapper.Map<List<DrawerRangeResponse>>(drawers);
        }

        public DrawerRangeResponse FindDrawerRangeResourceById(int id)
        {
            var drawer = _dbContext.DrawerRanges
                .Where(x => x.Id.Equals(id))
                .Include(x => x.Customer)
                .FirstOrDefault();
            
            return _mapper
                .Map<DrawerRangeResponse>(drawer);
        }

        public DrawerRange FindDrawerRangeById(int id)
        {
            return _dbContext.DrawerRanges
                .Include(x => x.Customer)
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public void CreateDrawerRange(DrawerRangeRequest drawer)
        {
            _dbContext.DrawerRanges.Add(_mapper.Map<DrawerRange>(drawer));
            _dbContext.SaveChanges();
        }

        public DrawerRangeResponse UpdateDrawerRange(int id, DrawerRangeRequest drawer)
        {
            var drawerToChange = _dbContext.DrawerRanges.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(drawer, drawerToChange);
            
            _dbContext.DrawerRanges.Update(drawerToChange);
            _dbContext.SaveChanges();
            return _mapper.Map<DrawerRangeResponse>(drawerToChange);
        }

        public void DeleteDrawerRange(DrawerRange drawer)
        {
            _dbContext.DrawerRanges.Remove(drawer);
            _dbContext.SaveChanges();
        }
    }
}