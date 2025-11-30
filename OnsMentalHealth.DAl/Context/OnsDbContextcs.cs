using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnsMentalHealthSolution.DAL.Entities;

namespace OnsMentalHealthSolution.DAL.Context
{
    public class OnsDbContext : IdentityDbContext<User>
    {
        public OnsDbContext(DbContextOptions<OnsDbContext> options) : base(options)
        {
        }

        
        public DbSet<Therapist> Therapists { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
           
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Therapist)
                .WithMany(t => t.comments) 
                .HasForeignKey(c => c.TherapistId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments) 
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade); 

            
            modelBuilder.Entity<Reaction>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reactions) 
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reaction>()
                .HasOne(r => r.Therapist)
                .WithMany(t => t.Reactions) 
                .HasForeignKey(r => r.TherapistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Therapist)
                .WithMany(t => t.Bookings)
                .HasForeignKey(b => b.TherapistId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}