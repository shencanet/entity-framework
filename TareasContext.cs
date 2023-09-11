using Microsoft.EntityFrameworkCore;
using Proyectoef.Models;


namespace Proyectoef;

public class TareasContesxt: DbContext{

    public Dbset<Categoria> Categorias {get; set;}
    public Dbset<Tarea> Tareas {get; set;}

    public TareasContesxt(DbContextOptions<TareasContesxt> options): base(options){}


}