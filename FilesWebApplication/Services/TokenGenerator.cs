using FilesWebApplication.Models;

namespace FilesWebApplication.Services
{
    public class TokenGenerator
    {
        public TokenModel GenerateToken(int id)
        {
            var guid = Guid.NewGuid().ToString("N");
            var rand = Random.Shared.Next(1000, 9999);


            return new TokenModel()
            {
                UserId = id,
                Token = $"{rand}_{guid}",
            };
        }
    }
}
