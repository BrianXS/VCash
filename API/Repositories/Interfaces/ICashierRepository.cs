using System.Collections.Generic;
using API.Entities;
using API.Entities.Administrative;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface ICashierRepository
    {
        CashierResponse FindCashierResponseById(int id);
        Cashier FindCashierById(int id);
        List<CashierResponse> GetAllCashiers();
        void CreateCashier(CashierCreateRequest cashier);
        void CreateCashiersRange(List<CashierCreateRequest> cashiers);
        CashierResponse UpdateCashier(int id, CashierUpdateRequest updatedCashier);
        void DeleteCashier(Cashier cashier);
        int CountCashiers();
    }
}