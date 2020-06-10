using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface IBranchRepository
    {
        BranchResponse FindBranchResponseById(int id);
        Branch FindBranchById(int id);
        List<BranchResponse> GetAllBranches();
        void CreateBranch(BranchCreateRequest branch);
        void CreateBranchRange(List<BranchCreateRequest> branches);
        BranchResponse UpdateBranch(int id, BranchUpdateRequest branch);
        void DeleteBranch(Branch branch);
        int CountBranches();
    }
}