using Microsoft.AspNetCore.Mvc;

namespace monsterKeepr.Controllers
{
    [Route("api/[controller]")]
  public class VaultKeepsController : Controller
  {
    private readonly VaultKeepsRepository db;
    public VualtKeepsController(VaultRepository repo)
    {
      db = repo;
    }
  }
}