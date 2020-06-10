using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface IStateRepository
    {
        StateResponse FindStateResourceById(int id);
        State FindStateById(int id);
        List<StateResponse> GetAllStates();
        void CreateState(StateCreateRequest states);
        void CreateStateRange(List<StateCreateRequest> state);
        StateResponse UpdateState(int id, StateUpdateRequest state);
        void DeleteState(State state);
        int CountStates();
    }
}