namespace ApiStore.Configuration;

public class DBConexion
{

    private readonly IConfiguration _configuration;

    public DBConexion(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetConnectionString()
    {
        return _configuration.GetConnectionString("ConeccionDB");
    }

}
