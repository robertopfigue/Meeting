using Meeting.Domain.Entities;
using Meeting.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Meeting.Domain.Interfaces.Repositories
{
    public interface IRepositoryRoom
    {
        Room AddRoom(Room room);

        List<Room> ListRoom();

        void SetReserved(Guid id);

        void SetFree(Guid id);
    }
}
