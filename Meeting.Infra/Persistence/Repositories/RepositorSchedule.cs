using Meeting.Domain.Entities;
using Meeting.Domain.Interfaces.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Meeting.Infra.Persistence.Repositories
{
    public class RepositorSchedule : IRepositorySchedule
    {
        protected readonly MeetingContext _context;

        public RepositorSchedule(MeetingContext context)
        {
            _context = context;
        }

        public Schedule AddSchedule(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            _context.SaveChanges();

            return schedule;
        }

        public List<Schedule> ListSchedules()
        {
            var list = new List<Schedule>();


            if (_context.Schedules.Any()) 
            {
                return list = _context.Schedules.Include(x => x.Room).Where(x => x.Room.Id == x.RoomId).ToList();
            }
            else
            {
                return list;
            }
        }
    }
}
