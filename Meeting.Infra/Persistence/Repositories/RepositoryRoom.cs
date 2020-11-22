using Meeting.Domain.Entities;
using Meeting.Domain.Enum;
using Meeting.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Meeting.Infra.Persistence.Repositories
{
    public class RepositoryRoom : IRepositoryRoom
    {
        protected readonly MeetingContext _context;

        public RepositoryRoom(MeetingContext context)
        {
            _context = context;
        }

        public Room AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();

            return room;
        }

        public List<Room> ListRoom()
        {
            if (_context.Rooms.Any())
            {
                var list = new List<Room>();
                return list = _context.Rooms.ToList();
            }
            else
            {
                return null;
            }
        }

        public void SetReserved(Guid id)
        {
            var room = _context.Rooms.Where(x => x.Id == id).FirstOrDefault();
            room.Status = EnumRoomStatus.Reservada;
        }

        public void SetFree(Guid id)
        {
            var room = _context.Rooms.Where(x => x.Id == id).FirstOrDefault();
            room.Status = EnumRoomStatus.Livre;
        }
    }
}
