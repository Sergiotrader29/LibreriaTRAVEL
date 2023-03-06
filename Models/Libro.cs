namespace Library.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public List<Editoriales> Editoriales { get; set; }
        public string? Sinopsis { get; set; }
        public int? n_paginas { get; set; }

        
      
    }
}
