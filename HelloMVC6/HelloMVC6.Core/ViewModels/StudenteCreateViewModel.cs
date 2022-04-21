namespace HelloMVC6.Core.ViewModels;

public class StudenteCreateViewModel
{
    [Required(ErrorMessage = "Nome obbligatorio")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Cognome obbligatorio")]
    public string Cognome { get; set; }
}
