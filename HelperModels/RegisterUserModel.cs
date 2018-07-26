using System.ComponentModel.DataAnnotations;

namespace monsterKeepr.Models
{
  public class RegisterUserModel
  {
    [MaxLength(20)]
    public string Username { get; set; }
    [MaxLength(225), EmailAddress]
    public string Email { get; set; }
    [MinLength(4)]
    public string Password { get; set; }
  }
}