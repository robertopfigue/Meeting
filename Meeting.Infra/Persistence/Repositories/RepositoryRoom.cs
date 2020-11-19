using Meeting.Domain.Entities;
using Meeting.Domain.Interfaces.Repositories;
using System;
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

        public Room SelectRoom(Guid id)
        {
            var room = _context.Rooms.Where(x => x.Id == id).FirstOrDefault();

            if (room != null)
            {
                return room;
            }
            else
            {
                return null;
            }
        }
    }
}
