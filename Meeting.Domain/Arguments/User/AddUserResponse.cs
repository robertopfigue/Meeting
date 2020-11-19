using Meeting.Domain.Interfaces.Arguments;
using System;

namespace Meeting.Domain.Arguments.User
{
    public class AddUserResponse : IResponse
    {
        public string Email { get; set; }

        public string Message { get; set; }

        public static explicit operator AddUserResponse(Entities.User entidade)
        {
            return new AddUserResponse()
            {
                Email = entidade.Email.Address,
                Message = "Usuário cadastrado com sucesso"
            };
        }
    }
}
