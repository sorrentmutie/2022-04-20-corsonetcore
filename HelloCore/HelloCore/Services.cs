using HelloCore.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace HelloCore.Services
{
    public class HelloService : ISaluto
    {
        private IClock clock;
        private IConfiguration configuration;
        private ILogger<Startup> logger;

        public int Contatore { get; set; }

        public HelloService(IClock clock, IConfiguration configuration, ILogger<Startup> logger)
        {
            this.clock = clock;
            this.configuration = configuration;
            this.logger = logger;
        }
        public string SalutoDelGiorno()
        {
            Contatore += 1;
            logger.LogCritical($"Hai invocato Saluto del Giorno: {Contatore}");
            //return "Benvenuto in ASP.NET Core! Sono le " + DateTime.Now;
            var esempio = configuration["Esempio"];
            var nome = configuration["Esempio2:Nome"];
            var cognome = configuration["Esempio2:Cognome"];
            return $"Ciao, {nome} {cognome}! {esempio} in ASP.NET Core! Sono le " + clock.GetNow();

        }
    }

    public class BuonanotteService : ISaluto
    {
        public string SalutoDelGiorno()
        {
            return "Buonanotte da ASP.Net Core";
        }
    }

}
