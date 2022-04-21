

namespace HelloMVC6.Core.Services;

public class StaticStudentsService : IStudentsService
{
    private static List<Studente> listaStudenti = new List<Studente> {
         new Studente { Id = 1, Nome = "Mario", Cognome = "Rossi", Matricola = "A011",
          Esami = new List<Esame> { new Esame { Id = 1, Nome = "Algebra", Voto = 28, Data =
           DateTime.Today.AddDays(-14)},
          new Esame { Id = 2, Nome = "Fisica", Voto = 25, Data =
           DateTime.Today.AddDays(-7)}} },
         new Studente
         {
             Id = 2,
             Nome = "Luigi",
             Cognome = "Bianchi",
             Matricola = "A012",
             Esami = new List<Esame> { new Esame { Id = 1, Nome = "Filosofia", Voto = 24, Data =
           DateTime.Today.AddDays(-14)},
          new Esame { Id = 2, Nome = "Etica", Voto = 30, Data =
           DateTime.Today.AddDays(-7)}}
         }
        };

    public int CreateStudent(StudenteCreateViewModel studente)
    {
        var id = listaStudenti.Max(x => x.Id) + 1;
        var nuovoStudente = new Studente
        {
            Nome = studente.Nome,
            Cognome = studente.Cognome,
            Id = id,
            Matricola = Guid.NewGuid().ToString(),
            Esami = new List<Esame>()
        };
        listaStudenti.Add(nuovoStudente);
        return id;
    }

    public Studente GetStudent(int id)
    {
        return listaStudenti.FirstOrDefault(s => s.Id == id);
    }

    public IEnumerable<StudentiIndexViewModel> GetStudentiIndexViewModel()
    {
        var vm = listaStudenti.Select(
            studente => new StudentiIndexViewModel
            {
                 Id = studente.Id,
                 NomeCompleto = studente.Nome + " " + studente.Cognome, 
                 MediaEsami = studente.Esami.Count > 0 ?   studente.Esami.Average(esame => esame.Voto): 0.0,
                 Matricola = studente.Matricola
            });
        return vm;
    }

    public IEnumerable<Studente> GetStudents()
    {
        return listaStudenti;
    }

    public int UltimoIdGenerato()
    {
        return listaStudenti.Max(x=> x.Id);
    }

    public void UpdateStudent(Studente studente)
    {
        var studenteDallaLista = listaStudenti.FirstOrDefault(x => x.Id == studente.Id);
        if(studenteDallaLista != null)
        {
            listaStudenti.Remove(studenteDallaLista);
            listaStudenti.Add(studente);
        }
    }
}
