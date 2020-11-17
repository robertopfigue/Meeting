using Meeting.Domain.Interfaces.Services;

namespace Meeting.Domain.Arguments.User
{
    public class AuthenticateUserRequest : IRequest
    {
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
