using System.Data;

namespace monsterKeepr.Repositories
{
  public abstract class DbContext
  {
    protected readonly IDbConnection _db;

    public DbContext(IDbConnection db)
    {
      _db = db;
    }
  }
}