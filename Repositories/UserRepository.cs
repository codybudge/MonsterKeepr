using System.Data;
using System;


namespace monsterKeepr.Repositories
{
public class UserRepository : DbContext
{
  public UserRepository(IDbConnection db) : base(db)
  {
  }
  public UserReturnModel Register(RegisterUserModel creds)
  {
    try
    {
      var sql = @"
      INSERT INTO users(id, username, email, password)
      VALUES (@Id, @Username, @Email, @Password);
      ";
      creds.Password = BCrypt.Net.BCrypt.HashPassword(creds.Password);
      var id = Guid.NewGuid().ToString();
      _db.ExecuteScalar<string>(sql, new
      {
        Id = id,
        Username = creds.username,
        Email = creds.email,
        Password = creds.password
      });
      return new UserReturnModel()
      {
       Id = id,
       Username = creds.username,
       Email = creds.email
      };
    }
    catch (MySqlException e)
    {
      System.Console.WriteLine("ERROR: " + e.Message);
      return null;
    }
  }
}
}