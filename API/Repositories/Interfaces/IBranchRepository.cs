using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;

namespace API.Repositories.Interfaces
{
    public interface IBranchRepository
    {
        BranchResponse FindBranchResponseById(int id);
        Branch FindBranchById(int id);
        List<BranchResponse> GetAllBranches();
        void CreateBranch(BranchCreateRequest branch);
        BranchResponse UpdateBranch(int id, BranchUpdateRequest branch);
        void DeleteBranch(Branch branch);
    }
}