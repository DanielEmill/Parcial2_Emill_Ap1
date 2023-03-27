using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class ProductosBLL {
    private readonly Contexto _contexto;

    public ProductosBLL(Contexto contexto) {
        _contexto = contexto;
    }

    public bool Existe(int ProductoId) {
        return _contexto.productos.Any(o => o.ProductoId == ProductoId);
    }

    public bool Inserta(Productos producto) {
        _contexto.productos.Add(producto);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Productos producto) {
        var productoExistente = _contexto.productos.Find(producto.ProductoId);
        if (productoExistente != null) {
            _contexto.Entry(productoExistente).CurrentValues.SetValues(producto);
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }

    public bool Guardar(Productos producto) {
        if (!Existe(producto.ProductoId))
            return Inserta(producto);
        else
            return Modificar(producto);
    }

    public bool Eliminar(int ProductoId) {
        var productoAEliminar = _contexto.productos.Where(o => o.ProductoId == ProductoId).SingleOrDefault();
        if (productoAEliminar != null) {
            _contexto.Entry(productoAEliminar).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }

    public Productos? Buscar(int ProductoId) {
        return _contexto.productos.Where(o => o.ProductoId == ProductoId).AsNoTracking().SingleOrDefault();
    }

    public List<Productos> GetList(Expression<Func<Productos, bool>> criterio) {
        return _contexto.productos.AsNoTracking().Where(criterio).ToList();
    }
}