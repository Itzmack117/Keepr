namespace Keepr.Models
{
  public class Vault
  {
    public int Id { get; set;}

    public string UserId {get; set;}
    public string Description { get; set;}
    public string Name { get; set;}
    public int Keeps {get; set;}
  }
}