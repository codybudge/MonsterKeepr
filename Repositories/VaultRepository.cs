using System.Collections.Generic;
using System.Data;
using System.Linq;
using API_Users.Models;
using Dapper;

namespace monsterKeepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;

    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Vault> GetAll(string id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @id", new { id });
    }
    public Vault GetById(string id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE id = @id", new { id }).FirstOrDefault();
    }
    public Vault AddVault(Vault newVualt)
    {
      _db.ExecuteScalar<string>(@"
      INSERT INTO vaults (name, description, userId)
      VAULUES(@Name, @Description, @UserId);
      SELECT LAST_INSERT_ID()", newVualt);

      return newVualt;
    }
  }
}