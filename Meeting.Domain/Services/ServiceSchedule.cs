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

        public ServiceSchedule(IRepositorySchedule repositorySchedule)
        {
            _repositorySchedule = repositorySchedule;
        }

        public AddScheduleResponse AddSchedule(AddScheduleRequest request)
        {
            var date = new Date(request.InitialDate, request.FinalDate);

            var schedule = new Schedule(request.Title, request.Room, date);

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
                AddNotification("Agendamento", "Está sala já foi agendada neste horário.");

                AddNotifications(schedule);

                return null;
            }

            return (AddScheduleResponse)schedule;
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
                if (schedule.RoomId == room && initialDate >= schedule.Date.InitialDate && finalDate <= schedule.Date.FinalDate)
                {
                    return false;
                }
            }

            return true;
        }

        //public void VerificaReserved()
        //{
        //    var list = _repositorySchedule.ListSchedules();

        //    if (list.Any())
        //    {
        //        foreach (var schedule in list)
        //        {
        //            if (DateTime.Now >= schedule.Date.InitialDate && DateTime.Now <= schedule.Date.FinalDate)
        //            {
        //                schedule.Room.Status = Enum.EnumRoomStatus.Reservada;
        //            }
        //            else
        //            {
        //                schedule.Room.Status = Enum.EnumRoomStatus.Livre;
        //            }
        //        }
        //    }
        //}

    }
}
