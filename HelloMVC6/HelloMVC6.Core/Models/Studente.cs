namespace HelloMVC6.Core.Models;

public class Studente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Matricola { get; set; }
    public List<Esame> Esami { get; set; }= new List<Esame>();

    public override string ToString()
    {
        return $"{Nome} {Cognome}: {Matricola}";
    }
}
