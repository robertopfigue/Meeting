using Meeting.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Meeting.Domain.Interfaces.Repositories
{
    public interface IRepositoryRoom
    {
        Room AddRoom(Room room);

        List<Room> ListRoom();

    }
}
