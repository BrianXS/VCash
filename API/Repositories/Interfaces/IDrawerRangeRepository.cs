using System.Collections.Generic;
using API.Entities;
using API.Entities.Administrative;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface IDrawerRangeRepository
    {
        List<DrawerRangeResponse> GetAllDrawerRanges();
        DrawerRangeResponse FindDrawerRangeResourceById(int id);
        DrawerRange FindDrawerRangeById(int id);
        void CreateDrawerRange(DrawerRangeRequest drawerRangeRequest);
        void CreateDrawerRange(List<DrawerRangeRequest> drawerRangeRequest);
        DrawerRangeResponse UpdateDrawerRange(int Id, DrawerRangeRequest drawerRangeRequest);
        void DeleteDrawerRange(DrawerRange drawerRange);
        int CountDrawerRanges();
    }
}