namespace aspnetloginNrTwo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Pw {  get; set; }
        public string Role { get; set; } = "User";  //lägger till så att om ingen roll applyas så blir det en User by default
    }
}
