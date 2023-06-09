using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class EmpacadosBLL
{
    private Contexto _contexto;
    public EmpacadosBLL(Contexto contexto){
        _contexto = contexto;
    }
    public bool Existe(int empacadoId){
        return _contexto.Empacados.Any(o => o.EmpacadoId == empacadoId );
    }
    private bool Insertar(Empacados empacado){
        
        var mixto = _contexto.productos.Find(6);

        foreach (var detalle in empacado.EmpacadoDetalle)
        {
            var producto = _contexto.productos.Find(detalle.ProductoId);
            if(producto!=null){
                producto.Existencia -= detalle.Cantidad;
                mixto!.Existencia += empacado.Cantidad;
                _contexto.Entry(producto).State = EntityState.Modified;
                _contexto.Entry(mixto).State = EntityState.Modified;
                _contexto.SaveChanges();
            }
        }
        _contexto.Empacados.Add(empacado);
        bool paso = _contexto.SaveChanges() > 0;
        _contexto.Entry(empacado).State = EntityState.Detached;
        return paso;
    }
private bool Modificar(Empacados empacado)
{
    var detallesOriginales = _contexto.Empacados.AsNoTracking().Where(o => o.EmpacadoId== empacado.EmpacadoId)
            .Include(o =>  o.EmpacadoDetalle)
            .AsNoTracking()
            .SingleOrDefault();
    
    var mixto = _contexto.productos.Find(6);

    foreach (var detalle in detallesOriginales.EmpacadoDetalle)
    {
        var producto = _contexto.productos.Find(detalle.ProductoId);
        if(producto!=null){
            producto.Existencia += detalle.Cantidad;
            mixto!.Existencia -= detallesOriginales.Cantidad;
            _contexto.Entry(producto).State = EntityState.Modified;
            _contexto.Entry(mixto).State = EntityState.Modified;
        }
    }

    foreach (var detalle in empacado.EmpacadoDetalle)
    {
        var producto = _contexto.productos.Find(detalle.ProductoId);
        if(producto!=null){
            producto.Existencia -= detalle.Cantidad;
            mixto!.Existencia += empacado.Cantidad;
            _contexto.Entry(producto).State = EntityState.Modified;
            _contexto.Entry(mixto).State = EntityState.Modified;
        }
    }

    var DetalleEliminar = _contexto.Set<EmpacadoDetalle>().Where(o => o.EmpacadoId == empacado.EmpacadoId);
    _contexto.Set<EmpacadoDetalle>().RemoveRange(DetalleEliminar);
    _contexto.Set<EmpacadoDetalle>().AddRange(empacado.EmpacadoDetalle);

    _contexto.Entry(empacado).State = EntityState.Modified;
    bool paso = _contexto.SaveChanges() >0;
    _contexto.Entry(empacado).State = EntityState.Detached;
    return paso; 
}

    public bool Guardar(Empacados empacado){
        if(!Existe(empacado.EmpacadoId)){
            return this.Insertar(empacado);
        }
        else{
            return this.Modificar(empacado);
        }
    }
public bool Eliminar(Empacados empacado){

        var mixto = _contexto.productos.Find(6);
        foreach (var detalle in empacado.EmpacadoDetalle)
        {
            var producto = _contexto.productos.Find(detalle.ProductoId);
            if(producto!=null){
                producto.Existencia += detalle.Cantidad;
                mixto!.Existencia -= empacado.Cantidad;
                _contexto.Entry(producto).State = EntityState.Modified;
                _contexto.Entry(mixto).State = EntityState.Modified;
                _contexto.SaveChanges();
            }
        }
        _contexto.RemoveRange(empacado.EmpacadoDetalle);
        _contexto.Entry(empacado).State = EntityState.Deleted;
        bool save = _contexto.SaveChanges() >0;
        _contexto.Entry(empacado).State = EntityState.Detached;
        return  save; 
}
/*
    public bool Eliminar(int empacado)
    {
    var empacadoABorrar = _contexto.Empacados.Where(o=> o.EmpacadoId == empacado).SingleOrDefault();
        if(empacadoABorrar!=null){
        foreach (var detalle in empacadoABorrar.EmpacadoDetalle)
        {
            var producto = _contexto.productos.Find(detalle.ProductoId);
            if(producto!=null){
                producto.Existencia += detalle.Cantidad;
                _contexto.Entry(producto).State = EntityState.Modified;
                _contexto.SaveChanges();
            }
        }
        _contexto.RemoveRange(empacadoABorrar.EmpacadoDetalle);
        _contexto.Entry(empacadoABorrar).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
        }
        return false;
    }*/
    public Empacados? Buscar(int empacadoId){
        return _contexto.Empacados
        .Include(o =>  o.EmpacadoDetalle).Where(o=> o.EmpacadoId == empacadoId).AsNoTracking().SingleOrDefault();
    }
    public List <Empacados> GetList(Expression < Func < Empacados, bool >> criterio){
        return _contexto.Empacados.AsNoTracking().Where(criterio).ToList();
    }
}