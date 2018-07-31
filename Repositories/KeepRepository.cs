using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using monsterKeepr.Models;

namespace monsterKeepr
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;

    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keep WHERE public = 1");
    }
    public Keep GetById(int id)
    {
      return _db.Query<Keep>("SELECT * FROM keep WHERE id = @id", new { id }).FirstOrDefault();
    }

    public Keep AddKeep(Keep newKeep)
    {
      _db.ExecuteScalar<string>(@"
      INSERT INTO keep (url, name, description, userId)
      VALUES(@Url, @Name, Description, @UserId);
      SELECT LAST_INSERT_ID()", newKeep);

      return newKeep;
    }

    internal IEnumerable<Keep> GetUserKeep(string userId)
    {
      return _db.Query<Keep>("SELECT * FROM keep WHERE userId = @userId", new { userId });
    }

    internal void EditKeep(Keep keep)
    {
      _db.Execute(@"
      views = @Views,
      saves = @Saves,
      public - @Public
      WHERE id = @Id", keep);
    }
  }
}