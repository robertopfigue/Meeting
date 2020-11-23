using Meeting.Domain.Arguments.Room;
using Meeting.Domain.Entities;
using Meeting.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace Meeting.Domain.Interfaces.Services
{
    public interface IServiceRoom : IServiceBase
    {
        AddRoomResponse AddRoom(AddRoomRequest request);

        IEnumerable<ListRoomResponse> ListEmpstyRooms();
        IEnumerable<ListRoomReservedResponse> ListReservedRooms();
        List<Room> ListRoom();
    }
}
