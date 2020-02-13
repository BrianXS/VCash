using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;

namespace API.Repositories.Interfaces
{
    public interface ICashierRepository
    {
        CashierResponse FindCashierResponseById(int id);
        Cashier FindCashierById(int id);
        List<CashierResponse> GetAllCashiers();
        void CreateCashier(CashierCreateRequest cashier);
        CashierResponse UpdateCashier(int id, CashierUpdateRequest updatedCashier);
        void DeleteCashier(Cashier cashier);
    }
}