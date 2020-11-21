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

            var schedule = new Schedule(request.Title, request.Room, request.User, date);

            AddNotifications(schedule);

            if (schedule.IsInvalid())
            {
                return null;
            }

            if (ScheduleIsValid(schedule.RoomId))
            {
                schedule = _repositorySchedule.AddSchedule(schedule);
            }
            else
            {
                AddNotification("Agendamento", "Está sala já está agendada neste horário.");

                AddNotifications(schedule);

                return null;
            }

            return (AddScheduleResponse)schedule;
        }

        public bool ScheduleIsValid(Guid room)
        {
            var list = new List<Schedule>();
            list = _repositorySchedule.ListSchedules();

            if (!list.Any())
            {
                return true;
            }

            foreach (var schedule in list)
            {
                if (schedule.Room.Status != Enum.EnumRoomStatus.Livre)
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
