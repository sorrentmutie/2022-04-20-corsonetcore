namespace HelloMVC6.Core.Interfaces;

public interface IStudentsService
{
    IEnumerable<Studente> GetStudents();
    Studente GetStudent(int id);
    IEnumerable<StudentiIndexViewModel> GetStudentiIndexViewModel();
    int CreateStudent(StudenteCreateViewModel studente);
    void UpdateStudent(Studente studente);
    int UltimoIdGenerato();
}
