using Meeting.Domain.Arguments.Room;
using Meeting.Domain.Entities;
using Meeting.Domain.Interfaces.Repositories;
using Meeting.Domain.Interfaces.Services;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meeting.Domain.Services
{
    public class ServiceRoom : Notifiable, IServiceRoom
    {
        private readonly IRepositoryRoom _repositoryRoom;
        private readonly IRepositorySchedule _repositorySchedule;

        public ServiceRoom(IRepositoryRoom repositoryRoom, IRepositorySchedule repositorySchedule)
        {
            _repositoryRoom = repositoryRoom;
            _repositorySchedule = repositorySchedule;
        }

        public AddRoomResponse AddRoom(AddRoomRequest request)
        {
            Room room = new Room(request.Number);

            AddNotifications(room);

            if (room.IsInvalid())
            {
                return null;
            }

            if (RoomExists(room.Number))
            {
                AddNotification("Sala", "Está sala já existe no cadastro.");

                AddNotifications(room);

                return null;
            }

            room = _repositoryRoom.AddRoom(room);

            return (AddRoomResponse)room;
        }

        public IEnumerable<ListRoomResponse> ListEmpstyRooms()
        {
            List<Room> roomsEmpty = new List<Room>();
            var schedules = _repositorySchedule.ListSchedules();
            var rooms = ListRoom();
            
            if (rooms != null)
            {
                foreach (var r in rooms)
                {
                    if (!schedules.Any(x => x.RoomId == r.Id))
                    {
                        roomsEmpty.Add(r);
                    }
                }
            }
            else
            {
                return null;
            }

            return roomsEmpty.ToList().Select(y => (ListRoomResponse)y).ToList();
        }

        public IEnumerable<ListRoomReservedResponse> ListReservedRooms()
        {
            List<Room> roomsEmpty = new List<Room>();
            var schedules = _repositorySchedule.ListSchedules();
            var rooms = ListRoom();

            if (rooms != null)
            {
                foreach (var r in rooms)
                {
                    if (schedules.Any(x => x.RoomId == r.Id))
                    {
                        if (!roomsEmpty.Any() || roomsEmpty.Any(x => x.Id != r.Id))
                        {
                            roomsEmpty.Add(r);
                        }
                    }
                }
            }
            else
            {
                return null;
            }

            return roomsEmpty.ToList().Select(y => (ListRoomReservedResponse)y).ToList();
        }

        public List<Room> ListRoom()
        {
            var rooms = new List<Room>();
            rooms = _repositoryRoom.ListRoom();

            return rooms;
        }

        public bool RoomExists(int number)
        {
            var rooms = _repositoryRoom.ListRoom();
            if (rooms == null)
            {
                return false;
            }
            else
            {
                return rooms.Any(x => x.Number == number);
            }
        }
    }
}
