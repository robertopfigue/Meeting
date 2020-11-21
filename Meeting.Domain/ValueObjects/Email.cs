using Meeting_Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace Meeting.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email()
        {
        }
        public Email(string address)
        {
            Address = address;

            new AddNotifications<Email>(this).IfNotEmail(x => x.Address, Message.X0_INVALIDO.ToFormat("E-mail"));
        }

        public string Address{ get; private set; }
    }
}
