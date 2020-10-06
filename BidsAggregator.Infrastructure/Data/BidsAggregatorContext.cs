using BidsAggregator.Core.Entities;
using BidsAggregator.Core.Entities.Inquiry;
using BidsAggregator.Core.Entities.TempolaryInquiry;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BidsAggregator.Infrastructure.Data
{
    public sealed class BidsAggregatorContext : DbContext
    {
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<Inquirer> Inquirers { get; set; }

        public DbSet<TempolaryInquiry> TempolaryInquiries { get; set; }
        public DbSet<TempolaryInquirer> TempolaryInquirers { get; set; }

        public DbSet<Performer> Performers { get; set; }
        

        public BidsAggregatorContext(DbContextOptions<BidsAggregatorContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
