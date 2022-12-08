using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VraiVraiVraiVraiPremierASP.Models;

namespace VraiVraiVraiVraiPremierASP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Personne> Personnes { get; set; }       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}