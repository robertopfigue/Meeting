using Meeting_Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace Meeting.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name()
        {
        }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new AddNotifications<Name>(this)
                .IfNullOrEmptyOrInvalidLength(x => x.FirstName, 3, 15, Message.X0_INVALIDO.ToFormat("Primeiro Nome"))
                .IfNullOrEmptyOrInvalidLength(x => x.LastName, 3, 15, Message.X0_INVALIDO.ToFormat("Ultimo Nome"));
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
