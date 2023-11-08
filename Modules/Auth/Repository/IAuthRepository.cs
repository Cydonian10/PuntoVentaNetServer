using ApiStore.Data;

namespace ApiStore.Modules.Auth;

public interface IAuthRepository
{
    Task<Data.AuthUser> Register(AuthRegisterDto dto);
}
