using Meeting.Domain.Arguments.Schedule;
using Meeting.Domain.Entities;
using Meeting.Domain.Interfaces.Services;
using Meeting.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using Meeting.Domain.Interfaces.Repositories;
using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace Meeting.Domain.Services
{
    public class ServiceSchedule : Notifiable, IServiceSchedule
    {
        private readonly IRepositorySchedule _repositorySchedule;
        private readonly IRepositoryRoom _repositoryRoom;

        public ServiceSchedule(IRepositorySchedule repositorySchedule, IRepositoryRoom repositoryRoom)
        {
            _repositorySchedule = repositorySchedule;
            _repositoryRoom = repositoryRoom;
        }

        public AddScheduleResponse AddSchedule(AddScheduleRequest request)
        {
            if (RoomExist(request.Room))
            {
                var date = new Date(request.InitialDate, request.FinalDate);

                var schedule = new Schedule(request.Title, SelectGuidRoom(request.Room), date);

                AddNotifications(schedule);

                if (schedule.IsInvalid())
                {
                    return null;
                }

                if (ScheduleIsValid(schedule.RoomId, schedule.Date.InitialDate, schedule.Date.FinalDate))
                {
                    schedule = _repositorySchedule.AddSchedule(schedule);
                }
                else
                {
                    return null;
                }

                return (AddScheduleResponse)schedule;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<ListScheduleResponse> ListSchedule()
        {
            var list = new List<Schedule>();
            list = _repositorySchedule.ListSchedules();

            return list.ToList().Select(schedule => (ListScheduleResponse)schedule).ToList();
        }

        public bool ScheduleIsValid(Guid room, DateTime initialDate, DateTime finalDate)
        {
            var list = new List<Schedule>();
            list = _repositorySchedule.ListSchedules();

            if (!list.Any())
            {
                return true;
            }

            foreach (var schedule in list)
            {
                if (schedule.RoomId == room && initialDate >= schedule.Date.InitialDate && initialDate <= schedule.Date.FinalDate
                    ||finalDate >= schedule.Date.InitialDate && finalDate <= schedule.Date.FinalDate)
                {
                    AddNotification("Agendamento", $"Está sala já foi agendada neste horário {schedule.Date.InitialDate} á {schedule.Date.FinalDate}");

                    AddNotifications(schedule);

                    return false;
                }
            }

            return true;
        }

        public bool RoomExist(int number)
        {
           return _repositoryRoom.ListRoom().Any(x => x.Number == number);
        }

        public Guid SelectGuidRoom(int number)
        {
            var rooms = _repositoryRoom.ListRoom();
            var room = rooms.Where(x => x.Number == number).FirstOrDefault();

            return room.Id;
        }


    }
}
