using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Entities.Administrative;
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
    public class StateRepository : IStateRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public StateRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public StateResponse FindStateResourceById(int id)
        {
            var state = _dbContext.States.Where(x => x.Id.Equals(id))
                .Include(x => x.Cities).Include(x => x.Country).FirstOrDefault();
            
            return _mapper.Map<StateResponse>(state);
        }

        public State FindStateById(int id)
        {
            return _dbContext.States.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<StateResponse> GetAllStates()
        {
            var states = _dbContext.States
                .Include(x => x.Cities).Include(x => x.Country).ToList();
            
            return _mapper.Map<List<StateResponse>>(states);
        }

        public void CreateState(StateCreateRequest state)
        {
            _dbContext.States.Add(_mapper.Map<State>(state));
            _dbContext.SaveChanges();
        }

        public void CreateStateRange(List<StateCreateRequest> states)
        {
            _dbContext.States.AddRange(_mapper.Map<List<State>>(states));
            _dbContext.SaveChanges();
        }

        public StateResponse UpdateState(int id, StateUpdateRequest updatedState)
        {
            var stateToUpdate = _dbContext.States.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(updatedState, stateToUpdate);
            
            _dbContext.States.Update(stateToUpdate);
            _dbContext.SaveChanges();
            
            return _mapper.Map<StateResponse>(stateToUpdate);
        }

        public void DeleteState(State state)
        {
            _dbContext.States.Remove(state);
            _dbContext.SaveChanges();
        }

        public int CountStates()
        {
            return _dbContext.States.Count();
        }
    }
}