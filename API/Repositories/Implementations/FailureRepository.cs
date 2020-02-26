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
    public class FailureRepository : IFailureRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public FailureRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public FailureResponse FindFailureResponseById(int id)
        {
            var failure = _dbContext.Failures.FirstOrDefault(x => x.Id.Equals(id));
            return _mapper.Map<FailureResponse>(failure);
        }

        public Failure FindFailureById(int id)
        {
            return _dbContext.Failures.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<FailureResponse> GetAllFailures()
        {
            var failures = _dbContext.Failures.ToList();
            return _mapper.Map<List<FailureResponse>>(failures);
        }

        public void CreateFailure(FailureCreateRequest failure)
        {
            _dbContext.Failures.Add(_mapper.Map<Failure>(failure));
            _dbContext.SaveChanges();
        }

        public FailureResponse UpdateFailure(int id, FailureUpdateRequest updatedFailure)
        {
            var failureToUpdate = _dbContext.Failures.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(updatedFailure, failureToUpdate);

            _dbContext.Failures.Update(failureToUpdate);
            _dbContext.SaveChanges();
            
            return _mapper.Map<FailureResponse>(failureToUpdate);
        }

        public void DeleteFailure(Failure failure)
        {
            _dbContext.Failures.Remove(failure);
            _dbContext.SaveChanges();
        }
    }
}