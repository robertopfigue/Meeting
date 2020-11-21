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

            return list = _context.Schedules.Include(x => x.Room).Where(x => x.Room.Id == x.RoomId).
                Include(y => y.User).Where(y => y.User.Id == y.UserId).ToList();

            if (_context.Schedules.Any()) 
            {
                //foreach (var s in _context.Schedules)
                //{
                //    var roomquery = from room in _context.Rooms
                //                    where room.Id == _context.Schedules.FirstOrDefault().RoomId
                //                    select room;

                //    if (roomquery.Any())
                //    {
                //        foreach (var ro in roomquery)
                //        {
                //            s.Room.Id = ro.Id;
                //            s.Room.Number = ro.Number;
                //            s.Room.Status = ro.Status;
                //        }
                //    }

                //    var userquery = from user in _context.Users
                //                    where user.Id == _context.Schedules.FirstOrDefault().UserId
                //                    select user;

                //    foreach (var us in userquery)
                //    {
                //        s.User.Id = us.Id;
                //        s.User.Name = us.Name;
                //        s.User.Senha = us.Senha;
                //    }

                //    list.Add(s);
                //}
                //return _context.Schedules.ToList();
                //return list;
            }
            else
            {
                return list;
            }
        }
    }
}
