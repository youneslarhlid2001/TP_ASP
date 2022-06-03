using Microsoft.EntityFrameworkCore;

namespace TPASPnet5.data
{
    public class TP_APIDbContext:DbContext
    {
        public TP_APIDbContext(DbContextOptions<TP_APIDbContext> options) : base(options)
        {



        }

        public DbSet<Commande> achat { get; set; }
       
    }
}
