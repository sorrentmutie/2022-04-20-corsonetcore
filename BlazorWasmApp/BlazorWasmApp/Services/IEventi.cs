using BlazorWasmApp.Models;

namespace BlazorWasmApp.Services;

public interface IEventi
{
    List<Evento> EstraiEventi();
    List<Evento> EstraiEventiPassati();
    Evento EstraiUltimoEvento();
    void Aggiungi(Evento evento);
    void Modifica(Evento evento);
    Evento EstraiPerId(int id);
    void Elimina(Evento evento);
}
