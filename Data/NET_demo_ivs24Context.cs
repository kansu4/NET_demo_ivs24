using Microsoft.EntityFrameworkCore;
using NET_demo_ivs24.Models;

namespace NET_demo_ivs24;

    public class NET_demo_ivs24Context: DbContext
    {
        public NET_demo_ivs24Context(DbContextOptions<NET_demo_ivs24Context> options) : base(options) {}

        public DbSet<Item> Items {get; set;}
    }  