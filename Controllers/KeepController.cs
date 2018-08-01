using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using monsterKeepr.Models;

namespace monsterKeepr
{
  [Route("api/[controller]")]
  public class KeepController : Controller
  {
    private readonly KeepRepository db;
    public KeepController(KeepRepository repo)
    {
      db = repo;
    }

    //GET api/Keep
    [HttpGet]
    public IEnumerable<Keep> Get()
    {
      return db.GetAll();
    }
    
    [HttpGet("mykeeps")]
    public IEnumerable<Keep> GetUserKeep()
    {
      var userId = HttpContext.User.Identity.Name;
      return db.GetUserKeep(userId);
    }

    //GET api/keep/id
    [HttpGet("{id}")]
    public Keep Get(int id)
    {
      return db.GetById(id);
    }

    [Authorize]
    //Post api/keep
    [HttpPost]
    public Keep Post([FromBody]Keep newKeep)
    {
      var userId = HttpContext.User.Identity.Name;
      newKeep.userId = userId;
      if (ModelState.IsValid)
      {
        return db.AddKeep(newKeep);
      }
      return null;
    }
    //PUT api/keep/id
    [HttpPut("{id}")]
    public string Put(int id, [FromBody]Keep keep)
    {
      db.EditKeep(keep);
      return "Updated";
    }

    //DELETE api/keep/id
    [HttpDelete("{id}")]
    public void Delet(int id)
    {
    }
  }
}