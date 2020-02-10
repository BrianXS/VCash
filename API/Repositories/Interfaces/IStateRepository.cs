using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;

namespace API.Repositories.Interfaces
{
    public interface IStateRepository
    {
        StateResponse FindStateResourceById(int id);
        State FindStateById(int id);
        List<StateResponse> GetAllStates();
        void CreateState(StateCreateRequest state);
        StateResponse UpdateState(int id, StateUpdateRequest state);
        void DeleteState(State state);
    }
}