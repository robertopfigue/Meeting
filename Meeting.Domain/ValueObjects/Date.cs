using Meeting_Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace Meeting.Domain.ValueObjects
{
    public class Date : Notifiable
    {
        public Date()
        {

        }
        public Date(DateTime initialDate, DateTime finalDate)
        {
            InitialDate = initialDate;
            FinalDate = finalDate;

            new AddNotifications<Date>(this).IfGreaterThan(x => x.InitialDate, FinalDate, Message.X0_INVALIDA.ToFormat("Data"));
        }

        public DateTime InitialDate { get; private set; }
        public DateTime FinalDate { get; private set; }
    }
}
