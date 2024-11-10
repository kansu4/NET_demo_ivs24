using Microsoft.AspNetCore.Identity;

namespace NET_demo_ivs24.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}