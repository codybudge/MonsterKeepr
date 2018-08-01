using System.Collections.Generic;
using API_Users.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace monsterKeepr.Controllers
{
  [Route("api/[controller")]

  public class VualtController : Controller
  {
    private readonly VaultRepository db;
    public VualtController(VaultRepository repo)
    {
      db = repo;
    }

    //GET api/vault
    [Authorize]
    [HttpGet]
    public IEnumerable<Vault> Get()
    {
      var id = HttpContext.User.Identity.Name;
      return db.GetAll(id);
    }

    [Authorize]
    //POST api/vault
    [HttpPost]
    public Vault Post([FromBody]Vault newVualt)
    {
      var userId = HttpContext.User.Identity.Name;
      newVualt.userId = userId;
      if (ModelState.IsValid)
      {
        return db.AddVault(newVualt);
      }
      return null;
    }
  }
}