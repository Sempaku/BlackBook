using BlackBook.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.IO;

namespace BlackBook.Data
{
    public class DbContextCreator : IDbContextCreator
    {
        public ApplicationDbContext CreateDbContext()
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