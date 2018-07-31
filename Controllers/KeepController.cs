using Microsoft.AspNetCore.Mvc;

namespace monsterKeepr
{
  [Route("api/[controller]")]
  public class KeepController : Controller
{
  private readonly KeepRepository db;
}
}