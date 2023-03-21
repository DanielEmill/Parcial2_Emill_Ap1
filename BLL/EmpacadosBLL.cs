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
        _contexto.Empacados.Add(empacado);
        return _contexto.SaveChanges() > 0 ;
    }
    private bool Modificar(Empacados empacado){
        _contexto.Entry(empacado).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0 ;
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
        _contexto.Entry(empacado).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }
    public Empacados? Buscar(int empacadoId){
        return _contexto.Empacados.Include(o => o.EmpacadoDetalle).Where(o => o.EmpacadoId == empacadoId).AsNoTracking().SingleOrDefault();
    }
    public List <Empacados> GetList(Expression < Func < Empacados, bool >> criterio){
        return _contexto.Empacados.AsNoTracking().Where(criterio).ToList();
    }
    void InsertarDetalle(Empacados empacado){
    }


}