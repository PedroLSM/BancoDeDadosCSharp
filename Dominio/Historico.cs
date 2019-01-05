using BancoDeDados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Historico")]
    public class Historico
    {
        
        public int Id { get; set; }
        public int CursoId { get; set; }
        public int TraineeId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        // Detalhamento

        public Curso curso;
        public Trainee trainee;
        private int v1;
        private int v2;
        private DateTime dateTime1;
        private DateTime dateTime2;

        public Historico(int v1, int v2, DateTime dateTime1, DateTime dateTime2)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.dateTime1 = dateTime1;
            this.dateTime2 = dateTime2;
        }

        public Historico()
        {
        }

        public override string ToString()
        {
            return "Id: " + Id + " | CursoId: " + CursoId + " | TraineeId: " + TraineeId + " | DataInicio: " + DataInicio.ToString("dd/MM/yyyy") + " | DataFim: " + DataFim.ToString("dd/MM/yyyy");
        }

        public string HistoricoDetalhado()
        {
            return "Id: " + Id + " | Trainee: " + trainee.Nome + " | Curso: " + curso.Nome + " | Inicio: " + DataInicio.ToString("dd/MM/yyyy") + " | Fim: " + DataFim.ToString("dd/MM/yyyy");
        }
    }
    
}
