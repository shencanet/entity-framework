namespace proyectoef.Models;
using System.ComponentModel.DataAnnotations;

public class Categoria
{
    [key]
    public Guid CategoriaId { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    [MaxLength(150, ErrorMessage = "El nombre no puede tener mas de 150 caracteres")]
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; }
  
}
```