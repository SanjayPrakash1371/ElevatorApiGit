using DataModels.Models;

namespace OneToManyExample.Controllers
{
    public class NewUsers
    {
        public string name { get; set; }
        public List<Accounts> accounts { get; set; }
    }
}