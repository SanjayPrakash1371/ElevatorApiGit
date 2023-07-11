using Microsoft.AspNetCore.Mvc.Authorization;
using System.Security.Principal;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AuthenticationExample.Authentication
{
    public class BasicAuthenticationAttribute:AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;

                string decodedAuthenticationToken=Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));

                string[] up = decodedAuthenticationToken.Split(':');

                string username= up[0]; 

                string password= up[1];

                EmployeeSecurity emp = new EmployeeSecurity();

                if (emp.Login(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }


                    
            }
        }
    }
}
