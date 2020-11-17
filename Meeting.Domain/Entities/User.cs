using Meeting.Domain.ValueObjects;
using System;

namespace Meeting.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public Name FirstName { get; set; }

        public Name LastName { get; set; }

        public Email Email { get; set; }

        public string Senha { get; set; }
    }
}
