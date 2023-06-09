using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    public DbSet <Productos> productos { get; set; }
    public DbSet <Empacados> Empacados { get; set; }
    public DbSet <EmpacadoDetalle> EmpacadosD { get; set; }

    public Contexto (DbContextOptions<Contexto> options) : base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Productos>().HasData(
            new Productos{
                ProductoId = 1,
                Descripcion = "Maní",
                Costo = 100,
                Precio = 25,
                Existencia = 225
            }
        );
        modelBuilder.Entity<Productos>().HasData(
            new Productos{
                ProductoId = 2,
                Descripcion = "Pistachos",
                Costo = 30,
                Precio = 15,
                Existencia = 225
            }
        );
        modelBuilder.Entity<Productos>().HasData(
            new Productos{
                ProductoId = 3,
                Descripcion = "Ciruelas",
                Costo = 25,
                Precio = 5,
                Existencia = 225
            }
        );
        modelBuilder.Entity<Productos>().HasData(
            new Productos{
                ProductoId = 4,
                Descripcion = "Pasas",
                Costo = 50,
                Precio = 10,
                Existencia = 225
            }
        );
        modelBuilder.Entity<Productos>().HasData(
            new Productos{
                ProductoId = 5,
                Descripcion = "Arándanos",
                Costo = 200,
                Precio = 100,
                Existencia = 225
            }
        );
        modelBuilder.Entity<Productos>().HasData(
            new Productos{
                ProductoId = 6,
                Descripcion = "Producto Mixto",
                Costo = 100,
                Precio = 300,
                Existencia = 0
            }
        );
    }
}