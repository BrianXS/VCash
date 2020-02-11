using System.Collections.Generic;
using API.Entities;
using API.Resources.Outgoing;

namespace API.Repositories.Interfaces
{
    public interface IBranchRepository
    {
        BranchResponse FindBranchResourceById(int id);
        Branch FindBranchById(int id);
        List<BranchResponse> GetAllBranches();
        void CreateBranch(BranchResponse branch);
        BranchResponse UpdateBranch(int id, BranchResponse branch);
        void DeleteBranch(Branch branch);
    }
}