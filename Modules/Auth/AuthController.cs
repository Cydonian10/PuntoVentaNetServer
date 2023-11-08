using ApiStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApiStore.Modules.Auth
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthRegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AuthUser newAuth = await _authRepository.Register(dto);

            return Ok(new
            {
                message = "Register Execute",
                data = newAuth
            });
        }

    }
}
