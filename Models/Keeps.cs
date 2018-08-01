namespace monsterKeepr.Models
{
  public class Keep
  {
    public string id { get; set; }
    public string Url { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string userId { get; set; }
    public int Views { get; set; }
    public int Saves { get; set; }
    public bool Public { get; set; }
  }
}