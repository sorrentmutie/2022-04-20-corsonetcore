using System.ComponentModel.DataAnnotations;

namespace BlazorWasmApp.Models;

public class Evento
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Nome obbligatorio")]
    [MaxLength(10, ErrorMessage = "Hai superato la lunghezza massima di {1} caratteri")]
    public string Nome { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Data { get; set; }
    [Required(ErrorMessage = "Località obbligatoria")]
    public string Localita { get; set; }
    public string Note { get; set; }
}
