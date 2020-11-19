using Meeting.Domain.Entities;
using Meeting.Domain.Interfaces.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            return _context.Schedules.ToList();
        }
    }
}
