using Meeting.Domain.Interfaces.Services;
using Meeting.Domain.ValueObjects;

namespace Meeting.Domain.Arguments.User
{
    public class AddUserRequest : IRequest
    {
        public Name FirstName { get; set; }

        public Name LastName { get; set; }

        public Email Email { get; set; }

        public string Senha { get; set; }
    }
}
