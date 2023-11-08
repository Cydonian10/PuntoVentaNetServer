using ApiStore.Data;

namespace ApiStore.Modules.Auth;

public class AuthRepository : IAuthRepository
{
    private readonly ApplicationContext context;
    public AuthRepository(ApplicationContext context)
    {
        this.context = context;
    }

    async public Task<Data.AuthUser> Register(AuthRegisterDto dto)
    {
        Data.AuthUser newAuth = new()
        {
            Id = Guid.NewGuid(),
            Email = dto.Email,
            Name = dto.Name,
            Password = dto.Password,
        };

        await context.Auths!.AddAsync(newAuth);
        await context.SaveChangesAsync();

        return newAuth;
    }
}
