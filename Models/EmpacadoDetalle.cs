using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class EmpacadoDetalle
{
    [Key]
    public int EmpacadoDetalleId { get; set; }
    public int EmpacadoId { get; set; }
    public int ProductoId { get; set; }
    public string? Descripcion { get; set; }
    public int Cantidad { get; set; }
}