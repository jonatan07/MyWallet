using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyWallet.Domain.Entities;
using MyWallet.Domain.Interfaces;
using MyWallet.Infrastructure.EntityTypeConfigurations;


namespace MyWallet.Infrastructure.Context
{
    public class BaseDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        private readonly string PrefixDb = "MyWallet";
        public BaseDbContext(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("DatabaseConnection");

            var databasePassword = Environment.GetEnvironmentVariable("DATABASE_PASSWD");
            var databaseUser = Environment.GetEnvironmentVariable("DATABASE_USER");
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            var databaseSchema = Environment.GetEnvironmentVariable("DATABASE_SCHEMA");

            if (!string.IsNullOrEmpty(databasePassword) && !string.IsNullOrEmpty(databaseUser) &&
                !string.IsNullOrEmpty(databaseUrl) && !string.IsNullOrEmpty(databaseSchema))
            {
                connectionString =
                    $"Data Source={databaseUrl}; Initial Catalog={databaseSchema}; User Id={databaseUser}; Password={databasePassword}; TrustServerCertificate=true";
            }

            options.UseSqlServer(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                builder.MigrationsHistoryTable($"{PrefixDb}__EFMigrationsHistory");
            });

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OperationConfigurations());
            modelBuilder.ApplyConfiguration(new WalletConfigurations());
        }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<Operations> Operations { get; set; }
    }
}
