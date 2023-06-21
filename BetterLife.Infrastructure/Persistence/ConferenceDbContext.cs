using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BetterLife.Infrastructure.Persistence
{
    public class ConferenceDbContext : IdentityDbContext
    {
        public ConferenceDbContext(DbContextOptions<ConferenceDbContext> options) : base(options) 
        {

        }

        public DbSet<Domain.Entities.Conference> Conferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.Conference>(eb =>
            {
                eb.Property(cn => cn.Type).IsRequired().HasMaxLength(100);
                eb.Property(cn => cn.DateOfMeetings);
                eb.Property(cn => cn.TicketPrice).IsRequired();
                eb.OwnsOne(a => a.Addresses);
            });
        }
    }
}
