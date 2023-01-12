using AutoMapper;

using DTOMappingWebApplication.Data;
using DTOMappingWebApplication.DTO;
using DTOMappingWebApplication.Entities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace DTOMappingWebApplication.Controllers;

[ApiController]
[Route("api/v1/user")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public UserController(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<HttpResponseMessage> AddUser(UserAddDTO? userAddDto)
    {
        if (userAddDto == null)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        var user = _mapper.Map<UserAddDTO, User>(userAddDto);

        user.PasswordHash = BitConverter.ToString(SHA256.HashData(Encoding.UTF8.GetBytes(userAddDto.Password!)));

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return new HttpResponseMessage(HttpStatusCode.OK);
    }

    [HttpGet("{id}")]
    public async Task<UserDTO?> GetUser(int? id)
    {
        if (id is null or 0)
        {
            return null;
        }

        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            return null;
        }

        return _mapper.Map<User, UserDTO>(user);
    }
}