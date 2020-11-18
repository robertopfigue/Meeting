using Meeting.Domain.Extensions;
using Meeting.Domain.ValueObjects;
using Meeting_Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace Meeting.Domain.Entities
{
    public class User : Notifiable
    {
        public User(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<User>(this)
                .IfNullOrEmptyOrInvalidLength(x => x.Senha, 6, 32, "A Senha deve ter entre 6 a 32 caracteres");

            if (IsValid())
            {
                Senha = Senha.ConvertToMD5();
            }
        }

        public User(Name name, Email email, string senha)
        {
            Name = name;
            Email = email;
            Senha = senha;
            Id = Guid.NewGuid();

            new AddNotifications<User>(this)
                .IfNullOrEmptyOrInvalidLength(x => x.Senha, 6, 32, Message.X0_INVALIDA.ToFormat("Senha"));

            if (IsValid())
            {
                Senha = Senha.ConvertToMD5();
            }

            AddNotifications(name, email);
        }

        public Guid Id { get; private set; }

        public Name Name { get; private set; }

        public Email Email { get; private set; }

        public string Senha { get; private set; }
    }
}
