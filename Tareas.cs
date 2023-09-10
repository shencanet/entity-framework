namespace projectoeft.Models
{
    public class Tarea
    {
        public Guid TareaId { get; set; }

        public Guid CategoriaId { get; set; }

        public string Titulo {get; set;}

        public string Descripcion {get; set;}

        // Foreign key
        public Guid CategoriaId { get; set; }
        // Navigation property
        public Categoria Categoria { get; set; }
    }
}