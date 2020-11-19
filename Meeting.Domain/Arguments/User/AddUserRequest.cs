using Meeting.Domain.Interfaces.Services;
using Meeting.Domain.ValueObjects;

namespace Meeting.Domain.Arguments.User
{
    public class AddUserRequest : IRequest
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
