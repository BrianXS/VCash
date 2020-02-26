using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface IATMRepository
    {
        ATMResponse FindATMResponseById(int id);
        ATM FindATMById(int id);
        List<ATMResponse> GetAllATM();
        void CreateATM(ATMCreateRequest atm);
        ATMResponse UpdateATM(int id, ATMUpdateRequest atm);
        void DeleteATM(ATM atm);
    }
}