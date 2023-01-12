using MongoDB.Bson;

namespace MongoDbWebApplication.Models;

public class User
{
    public ObjectId Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string Email { get; set; } = null!;
}
