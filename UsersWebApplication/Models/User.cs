namespace UsersWebApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
    }
}
