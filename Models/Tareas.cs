namespace proyectoeft.Models
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
{
    public class Tarea
    {
        [Key]
        public Guid TareaId { get; set; }

        [ForeigKey("CategoriaId")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "El titulo es requerido")]
        [MAXLength(200, ErrorMessage = "El titulo no puede tener mas de 200 caracteres")]
        public string Titulo {get; set;}

        public string Descripcion {get; set;}


        public Categoria Categoria { get; set; }

        public Prioridad Prioridad { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}

public enum  {

    Baja,
    Media,

    Alta
}