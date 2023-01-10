namespace DTOMappingWebApplication.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string? Email { get; set; }
}