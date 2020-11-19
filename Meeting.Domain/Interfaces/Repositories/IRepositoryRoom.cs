using Meeting.Domain.Entities;
using System;

namespace Meeting.Domain.Interfaces.Repositories
{
    public interface IRepositoryRoom
    {
        Room AddRoom(Room room);

        Room SelectRoom(Guid id);
    }
}
