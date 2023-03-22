using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Empacados
{
    [Key]
    public int EmpacadoId { get; set; }
    [Required(ErrorMessage = "La Fecha es obligatorio.")]
    public DateTime Fecha {get; set;} = DateTime.Now;
    [Required(ErrorMessage = "El concepto es obligatorio.")]
    public String? Concepto { get; set; }

    [ForeignKey("EmpacadoId")]
    public List<EmpacadoDetalle> EmpacadoDetalle { get; set; } = new List<EmpacadoDetalle>();

}