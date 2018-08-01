using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using monsterKeepr.Models;
using monsterKeepr.Repositories;

namespace monsterKeepr.Controllers
{
  [Route("api/[controller]")]
  public class VaultKeepsController : Controller
  {
    private readonly VaultKeepsRepository _db;
    public VaultKeepsController(VaultKeepsRepository repo) => _db = repo;

    [HttpPost]
    public VaultKeep CreateVaultKeep([FromBody]VaultKeep newVaultKeep)
    {
      if (ModelState.IsValid)
      {
        var user = HttpContext.User;
        var id = user.Identity.Name;
        newVaultKeep.UserId = id;
        return _db.CreateVaultKeep(newVaultKeep);
      }
      return null;
    }

    [HttpGet("vaultId")]
    public IEnumerable<Keep> GetKeepsInVault(int vaultId)
    {
      return _db.GetByKeepsInVault(vaultId);
    }
  }
}