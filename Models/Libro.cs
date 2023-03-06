using System.ComponentModel;

namespace Library.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [DisplayName("Título del libro")]
        public string Titulo { get; set; }
        public string Editoriales { get; set; }
        public string? Sinopsis { get; set; }
        public int? n_paginas { get; set; }
        public Autor Autor { get; set; }

        public AutorConLibro AutorConLibro { get; set; }

    }
}
