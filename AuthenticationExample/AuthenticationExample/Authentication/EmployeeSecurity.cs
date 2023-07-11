using AuthenticationExample.AllDbContext;

namespace AuthenticationExample.Authentication
{
    public class EmployeeSecurity
    {
        private  readonly AllDataAccess context;
        public EmployeeSecurity(AllDataAccess context)
        {
            this.context = context;
        }

        public EmployeeSecurity() { }
        public    bool Login(string username, string password)
        {

           return  context.users.Any(user=>user.username.Equals(username, StringComparison.OrdinalIgnoreCase)&&user.Password==password);
            
        }
    }
}
