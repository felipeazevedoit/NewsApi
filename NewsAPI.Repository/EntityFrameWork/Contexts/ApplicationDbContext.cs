using Microsoft.EntityFrameworkCore;
using NewsAPI.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace ewsAPI.Repository.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Source> Source { get; set; }
        public DbSet<NewsArticle> NewsArticle { get; set; }

        private readonly IConfiguration configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Base>().HasKey(e => e.Id);

            modelBuilder.Entity<NewsArticle>()
                .HasOne(a => a.Source)
                .WithMany()
                .HasForeignKey(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NewsArticle>()
                .HasOne(a => a.Category)
                .WithMany()
                .HasForeignKey(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
