using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NET_demo_ivs24.Models;

namespace NET_demo_ivs24.Data;

    public class NET_demo_ivs24Context: IdentityDbContext<Users>
    {   
        public NET_demo_ivs24Context(DbContextOptions<NET_demo_ivs24Context> options) : base(options) {}

        public DbSet<Item> Items {get; set;}
    }  