using System.ComponentModel.DataAnnotations;

public class EmpacadoDetalle
{
    [Key]
    public int EmpacadoDetalleId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage ="EL EmpacadoId debe de estar en el rango de {1} - {2}")]
    public int EmpacadoId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage ="EL ProductoId debe de estar en el rango de {1} - {2}")]
    public int ProductoId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage ="La cantidad debe de estar en el rango de {1} - {2}")]
    public int Cantidad { get; set; }
}