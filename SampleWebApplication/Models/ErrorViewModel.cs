namespace SampleWebApplication.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

public class PrivacyViewModel
{
    public Homework? Homework { get; set; }
    public User User { get; set; } = null!;
}

public class Homework
{
    public int Id { get; set; }
    public string Data { get; set; } = null!;
}

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
}