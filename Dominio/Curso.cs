using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    [Table("Cursos")]
    public class Curso
    {

        public Curso()
        {

        }

        public Curso(string nome, string autor, int carga)
        {
            this.Nome = nome;
            this.Autor = autor;
            this.CargaHoraria = carga;
        }

        public override string ToString()
        {
            return "Nome: " + Nome + " | Autor: " + Autor + " | Carga Horaria: " + CargaHoraria;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public int CargaHoraria { get; set; }

    }
}
