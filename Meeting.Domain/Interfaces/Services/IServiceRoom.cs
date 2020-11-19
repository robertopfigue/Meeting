using Meeting.Domain.Arguments.Room;
using Meeting.Domain.Entities;
using System;

namespace Meeting.Domain.Interfaces.Services
{
    public interface IServiceRoom
    {
        AddRoomResponse AddRoom(AddRoomRequest request);

        Room SelectRoom(Guid id);
    }
}
