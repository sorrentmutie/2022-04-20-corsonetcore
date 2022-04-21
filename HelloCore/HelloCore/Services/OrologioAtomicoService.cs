using HelloCore.Interfaces;
using System;

namespace HelloCore.Services
{
    public class OrologioAtomicoService : IClock
    {
        public OrologioAtomicoService()
        {

        }

        public int Contatore { get; set; }

        public DateTime GetNow()
        {
            Contatore += 1;
            return DateTime.UtcNow;
        }
    }

    public class OrologioMock : IClock
    {
        public DateTime GetNow()
        {
            
            return new DateTime(2000,1,1);
        }
    }
}
