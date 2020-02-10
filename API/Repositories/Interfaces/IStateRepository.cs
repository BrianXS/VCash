using System.Collections.Generic;
using API.Entities;
using API.Resources.Outgoing;

namespace API.Repositories.Interfaces
{
    public interface IStateRepository
    {
        StateResponse FindStateById(int id);
        List<StateResponse> GetAllStates();
        void CreateState();
        StateResponse UpdateState(State state);
        void DeleteState(State state);
    }
}