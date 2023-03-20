using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class ProductosBLL{
    private Contexto _contexto;
    public ProductosBLL(Contexto contexto){
        contexto = _contexto;
    }

    public List <Productos> GetList(Expression < Func < Productos, bool >> criterio){
        return _contexto.productos.AsNoTracking().Where(criterio).ToList();
    }
}