using CarCrud.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarCrud.Presentation.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureDB(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(connectionString));
        }
    }
}
