using System.Text;

using WebApiLibrary;

namespace UsersWebApplication.Services
{
    public class UserTokengenerator
    {
        public string Generate(User user)
        {
            var builder = new StringBuilder();

            builder.Append(user.FirstName);
            builder.Append(Guid.NewGuid().ToString("N"));

            return builder.ToString();
        }
    }
}
