namespace Hello6Vuoto.Services;

public class SalutoStatico : ISaluto
{
    private readonly IConfiguration configuration;

    public int Contatore { get; set; }

    public SalutoStatico(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string EstraiSaluto()
    {
        Contatore++;
        return configuration["Saluto"] + ": " + Contatore;
    }
}
