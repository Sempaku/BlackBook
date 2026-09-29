namespace BlackBook.Data.Interfaces
{
    public interface IDbContextCreator
    {
        ApplicationDbContext CreateDbContext();
    }
}