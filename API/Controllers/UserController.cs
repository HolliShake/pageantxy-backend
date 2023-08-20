using APP.Dto.UserDto;
using APP.IServices;
using AutoMapper;
using DOMAIN.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : GenericController<IUserService, User>
{
    public UserController(IMapper mapper, IUserService repo) : base(mapper, repo)
    {
    }

    // Get All
    [HttpGet("all", Name = "GetAllUser")]
    public async Task<ActionResult> GetAllUser()
    {
        return await GenericGetAll<GetUserDto>();
    }

    // Get by id
    [HttpGet("{id}", Name = "GetUser")]
    public async Task<ActionResult> GetUser(string id)
    {
        return await GenericGet<GetUserDto>(id);
    }

    // Create
    [HttpPost("create", Name = "CreateUser")]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserDto createBody)
    {
        return await GenericCreate(createBody);
    }

    // Update
    [HttpPut("update/{id}", Name = "UpdateUser")]
    public async Task<ActionResult> UpdateUser(string id, [FromBody] UpdateUserDto updateBody)
    {
        return await GenericUpdate(id, updateBody);
    }

    // Update
    [HttpPut("verify/{id}", Name = "VerifyUser")]
    public async Task<ActionResult> VerifyUser(string id)
    {
        return await GenericUpdate(id, new VerifyUserDto());
    }

    // Delete
    [HttpDelete("delete/{id}", Name = "DeleteUser")]
    public async Task<ActionResult> DeleteUser(string id)
    {
        return await GenericDelete(id);
    }
}