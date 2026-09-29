using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace BlackBook.Data.Tests
{
    public class DbContextCreator
    {
        public static ApplicationDbContext CreateDbContext()
        {
            var confFile = File.ReadAllText($@"{Directory.GetCurrentDirectory()}/appsettings.json");
            dynamic data = JObject.Parse(confFile);
            string conString = data.ConnectionStrings.DefaultConnection;

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseNpgsql(conString)
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}