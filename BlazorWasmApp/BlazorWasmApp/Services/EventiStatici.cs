using BlazorWasmApp.Models;

namespace BlazorWasmApp.Services;

public class EventiStatici : IEventi
{
    private static List<Evento> listaEventi = new List<Evento>
    {
        new Evento { Id = 1, Nome ="Corso Blazor", Localita="Remoto", Data = DateTime.Today},
        new Evento { Id = 2, Nome ="Corso Blazor 2", Localita="Remoto", Data = DateTime.Today},
        new Evento { Id = 3, Nome ="Corso Blazor 3", Localita="Remoto", Data = DateTime.Today},
        new Evento { Id = 4, Nome ="Corso Blazor 4", Localita="Remoto", Data = DateTime.Today}
    };

    private static List<Evento> listaEventiPassati = new List<Evento>
    {
        new Evento { Id = 1, Nome ="Corso .NET", Localita="Remoto", Data = DateTime.Today.AddDays(-7)},
        new Evento { Id = 2, Nome ="Corso .NET 2", Localita="Remoto", Data = DateTime.Today.AddDays(-7)},
        new Evento { Id = 3, Nome ="Corso .NET 3", Localita="Remoto", Data = DateTime.Today.AddDays(-7)},
        new Evento { Id = 4, Nome ="Corso .NET 4", Localita="Remoto", Data = DateTime.Today.AddDays(-7)}
    };

    public void Aggiungi(Evento evento)
    {
        var id = listaEventi.Max(x => x.Id) + 1;
        evento.Id = id;
        listaEventi.Add(evento);
    }

    public void Elimina(Evento evento)
    {
        listaEventi.Remove(evento);
    }

    public List<Evento> EstraiEventi()
    {
        return listaEventi.OrderBy(x=> x.Id).ToList();
    }

    public List<Evento> EstraiEventiPassati()
    {
        return listaEventiPassati;
    }

    public Evento EstraiPerId(int id)
    {
        return listaEventi.FirstOrDefault(x => x.Id == id);
    }

    public Evento EstraiUltimoEvento()
    {
        return listaEventi.OrderByDescending(x => x.Id).FirstOrDefault();
    }

    public void Modifica(Evento evento)
    {
        var elemento = listaEventi.FirstOrDefault( x=> x.Id == evento.Id );
        listaEventi.Remove(elemento);
        listaEventi.Add(evento);
    }
}
