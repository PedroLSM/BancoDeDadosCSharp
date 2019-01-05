using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    [Table("Trainees")]
    public class Trainee
    {
        public Trainee(string Nome)
        {
            this.Nome = Nome;
        }

        public Trainee()
        {
        }

        public override string ToString()
        {
            return "Nome: " + Nome;
        }

        public string Nome { get; set; }
        public int Id { get; set; }
    }
}
