using MyWallet.Infrastructure.Context;

namespace MyWallet.API.Extensions
{
    public static class HostDatabaseExtension
    {
        public static void InitDatabase(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BaseDbContext>();
                //db.Database.Migrate();

                // -------------
                //  Seeders
                // -------------
                /*
                MiscellaneousPaymentStatusSeeder.SeedData(db);
                DeductionSeeder.SeedData(db);
                PaymentMethodSeeder.SeedData(db);
                DocumentTypeSeeder.SeedData(db);
                */
            }
        }
    }
}
