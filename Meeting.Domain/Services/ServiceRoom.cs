using Meeting.Domain.Arguments.Room;
using Meeting.Domain.Entities;
using Meeting.Domain.Interfaces.Repositories;
using Meeting.Domain.Interfaces.Services;
using prmToolkit.NotificationPattern;
using System;

namespace Meeting.Domain.Services
{
    public class ServiceRoom : Notifiable, IServiceRoom
    {
        private readonly IRepositoryRoom _repositoryRoom;

        public ServiceRoom(IRepositoryRoom repositoryRoom)
        {
            _repositoryRoom = repositoryRoom;
        }

        public AddRoomResponse AddRoom(AddRoomRequest request)
        {
            Room room = new Room(request.Number);

            AddNotifications(room);

            if (room.IsInvalid())
            {
                return null;
            }

            room = _repositoryRoom.AddRoom(room);

            return (AddRoomResponse)room;
        }

        public Room SelectRoom(Guid id)
        {
            var room = _repositoryRoom.SelectRoom(id);

            return room;
        }
    }
}
