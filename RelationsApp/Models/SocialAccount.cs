namespace RelationsApp.Models
{
    public class SocialAccount
    {
        public int Id { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Vkontakt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
