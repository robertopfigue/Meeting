using Meeting.Domain.Arguments.User;
using Meeting.Domain.Interfaces.Services;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Unity;

namespace Meeting.Api.Security
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private readonly UnityContainer _container;

        public AuthorizationProvider(UnityContainer container)
        {
            _container = container;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                IServiceUser serviceUser = _container.Resolve<IServiceUser>();

                AuthenticateUserRequest request = new AuthenticateUserRequest();
                request.Email = context.UserName;
                request.Senha = context.Password;

                AuthenticateUserResponse response = serviceUser.AuthenticateUser(request);



                if (serviceUser.IsInvalid())
                {
                    if (response == null)
                    {
                        context.SetError("invalid_grant", "Preencha um e-mail válido e uma senha com pelo menos 6 caracteres.");
                        return;
                    }
                }

                serviceUser.ClearNotifications();

                if (response == null)
                {
                    context.SetError("invalid_grant", "Usuário não encontrado!");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                //Definindo as Claims
                identity.AddClaim(new Claim("User", JsonConvert.SerializeObject(response)));

                var principal = new GenericPrincipal(identity, new string[] { });

                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
                return;
            }
        }
    }
}