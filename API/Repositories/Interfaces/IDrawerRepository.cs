using System.Collections.Generic;
using API.Entities;
using API.Entities.Administrative;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface IDrawerRepository
    {
        List<DrawerResponse> GetAllDrawers();
        DrawerResponse FindDrawerResourceById(int id);
        Drawer FindDrawerById(int id);
        void CreateDrawer(DrawerRequest drawerRequest);
        void CreateDrawerRange(List<DrawerRequest>  drawerRequests);
        DrawerResponse UpdateDrawer(int Id, DrawerRequest drawerRequest);
        void DeleteDrawer(Drawer drawer);
        int CountDrawers();
    }
}