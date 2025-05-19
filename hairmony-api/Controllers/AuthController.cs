using hairmony_api.DTO;
using hairmony_api.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    // Injete seu serviço de usuário para validar credenciais
     private readonly ILoginService _loginService;

    public AuthController(IConfiguration configuration , ILoginService loginService)
    {
        _configuration = configuration;
        _loginService = loginService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginRequest)
    {
        // 1. Validar as credenciais do usuário
        var user = _loginService.ValidarUsuario(loginRequest.UserName, loginRequest.Password);
        if (user == null)
        {
            return Unauthorized(new { message = "Credenciais inválidas" });
        }

        // Supondo que você tenha o ID do salão após a validação bem-sucedida
        var salaoId = user.id; // Obtenha o ID do salão do usuário autenticado

        // 2. Criar as Claims
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, salaoId.ToString()), // ID do usuário
            new Claim(JwtRegisteredClaimNames.PreferredUsername, loginRequest.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // ID único do token
            // Adicione outras claims conforme necessário (ex: roles)
        };

        // 3. Obter a chave secreta e configurações do appsettings
        var jwtSettings = _configuration.GetSection("Jwt");
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
        var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        // 4. Definir as propriedades do token
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(10),
            Issuer = jwtSettings["Issuer"],
            Audience = jwtSettings["Audience"],
            SigningCredentials = credentials
        };

        // 5. Gerar o token
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        // 6. Retornar o token
        return Ok(new { token = tokenString, salao = salaoId });
    }
}
