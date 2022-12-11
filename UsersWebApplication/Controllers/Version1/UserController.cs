using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WebApiLibrary;
using UsersWebApplication.Services;
using Microsoft.AspNetCore.Cors;

namespace UsersWebApplication.Controllers.Version1
{
    [ApiController]
    [Route("api/v1/{controller}/{action}")]
    [EnableCors]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _userDbContext;

        public UserController(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        [HttpGet("{id:int}")]
        public async Task<User?> Get(int id)
        {
            return await _userDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }
        
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userDbContext.Users.ToListAsync();
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Add(User? user)
        {
            if (user == null)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = JsonContent.Create(new
                    {
                        Success = false,
                        Message = "Failed to create user"
                    })
                };
            }

            await _userDbContext.Users.AddAsync(user);
            await _userDbContext.SaveChangesAsync();

            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = JsonContent.Create(new
                {
                    Success = true,
                    Message = "User created"
                })
            };
        }
    }
}
