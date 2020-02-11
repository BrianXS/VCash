using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using API.Services.Database;
using AutoMapper;

namespace API.Repositories.Implementations
{
    public class BranchRepository : IBranchRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public BranchRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public BranchResponse FindBranchResponseById(int id)
        {
            var branch = _dbContext.Branches.FirstOrDefault(x => x.Id.Equals(id));
            return _mapper.Map<BranchResponse>(branch);
        }

        public Branch FindBranchById(int id)
        {
            return _dbContext.Branches.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<BranchResponse> GetAllBranches()
        {
            var branches = _dbContext.Branches.ToList();
            return _mapper.Map<List<BranchResponse>>(branches);
        }

        public void CreateBranch(BranchCreateRequest branch)
        {
            _dbContext.Branches.Add(_mapper.Map<Branch>(branch));
            _dbContext.SaveChanges();
        }

        public BranchResponse UpdateBranch(int id, BranchUpdateRequest updatedBranch)
        {
            var branchToUpdate = _dbContext.Branches.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(updatedBranch, branchToUpdate);

            _dbContext.Branches.Update(branchToUpdate);
            _dbContext.SaveChanges();

            return _mapper.Map<BranchResponse>(branchToUpdate);
        }

        public void DeleteBranch(Branch branch)
        {
            _dbContext.Branches.Remove(branch);
            _dbContext.SaveChanges();
        }
    }
}