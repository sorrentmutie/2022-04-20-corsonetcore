namespace HelloMVC6.Core.ViewModels;

public class StudentiIndexViewModel
{
    public int Id { get; set; }
    [Display(Name = "Nome Completo")]
    public string NomeCompleto { get; set; }
    [Display(Name = "Media Esami")]
    public double MediaEsami { get; set; }
    public string Matricola { get; set; }
}
