using Domain;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.Account)
                .WithOne(b => b.User)
                .HasForeignKey<Account>(b => b.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.AccountTransactions)
                .WithOne(p => p.User)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Account>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (AccountStatus)Enum.Parse(typeof(AccountStatus), v));

            modelBuilder.Entity<AccountTransaction>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (TransactionStatus)Enum.Parse(typeof(TransactionStatus), v));

            base.OnModelCreating(modelBuilder);
        }

    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../Api/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultDBConn");
            builder.UseSqlServer(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}
