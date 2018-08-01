using System.Collections.Generic;
using System.Data;
using Dapper;
using monsterKeepr.Models;

namespace monsterKeepr.Repositories
{
  public class VaultKeepsRepository : DbContext
  {
    public VaultKeepsRepository(IDbConnection db) : base(db)
    {
    }
    public VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaultkeeps (userId, vaultId, keepId)
      VALUES (@UserId, @VaultId, @KeepId);
      SELECT LAST_INSERT_ID();", newVaultKeep);
      newVaultKeep.Id = id;
      return newVaultKeep;
    }

    public IEnumerable<Keep> GetByKeepsInVault(int vaultId)
    {
      return _db.Query<Keep>(@"
      SELCT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE(vaultId = @vaultId)", new { vaultId });
    }
  }
}