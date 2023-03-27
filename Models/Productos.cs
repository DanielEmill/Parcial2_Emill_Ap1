using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Productos{
    [Key]
    public int ProductoId { get; set; }
    [Required(ErrorMessage = "La descripcion es obligatorio.")]
    public string? Descripcion { get; set; }
    [Range(1, Double.MaxValue, ErrorMessage ="El Costo debe de estar en el rango minimo de {1}")]
    public double Costo { get; set; }
    [Range(1, Double.MaxValue, ErrorMessage ="El Precio debe de estar en el rango de {1} - {2}")]
    public double Precio { get; set; }
    [Range(1, Double.MaxValue, ErrorMessage ="La Existencia debe de estar en el rango de {1} - {2}")]
    public int Existencia { get; set; }
}