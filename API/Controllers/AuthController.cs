using APP.Dto.AuthDto;
using APP.Dto.UserDto;
using AutoMapper;
using CQI.APPLICATION.Jwt;
using DOMAIN.model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IJwtAuthManager _jwtAuthManager;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthController(IMapper mapper, IJwtAuthManager jwtAuthManager, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _mapper = mapper;
        _jwtAuthManager = jwtAuthManager;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("login", Name = "Login")]
    public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
    {
        var existingUser = await _userManager.FindByEmailAsync(loginDto.Email);

        if (existingUser == null)
        {
            goto bad;
        }

        var result = await _signInManager.CheckPasswordSignInAsync(existingUser, loginDto.Password, false);

        if (result.Succeeded && !existingUser.IsAdminVerified)
        {
            return Unauthorized("Account is not verified by admin!");
        }

        if (result.Succeeded)
        {
            goto success;
        }
    bad:;
        return BadRequest("Invalid email or password");

    success:;
        var token = JwtGenerator.GenerateToken(
            _jwtAuthManager, 
            existingUser.Id, 
            existingUser.Email,
            existingUser.Role
        );
        
        var userData = _mapper.Map<GetUserDto>(existingUser);
        userData.AccessToken = token.AccessToken;
        userData.RefreshToken = token.RefreshToken.TokenString;

        return Ok(userData);
    }

    [HttpPost("register", Name = "Register")]
    public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var applicant = _mapper.Map<CreateUserDto>(registerDto);

        User newUser;
        var result = await _userManager.CreateAsync((newUser = _mapper.Map<User>(applicant)), registerDto.Password);


        if (result.Succeeded)
        {
            goto Ok;
        }

        Console.WriteLine($"==>> {newUser.UserName} ==>> {newUser.Email}");
        return BadRequest(result.Errors);

    Ok:;
        return Ok(newUser);
    }
}
