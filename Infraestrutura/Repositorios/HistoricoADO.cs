using BancoDeDados;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura
{
    public class HistoricoADO
    {
        private string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EstagioDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void InserirHistorico(Historico historico)
        {
            SqlConnection cx = new SqlConnection(ConnectionString);
            try
            {
                string cmd = "insert into Historico (CursoId, TraineeId, DataInicio, DataFim) values (@CursoId, @TraineeId, @DataInicio, @DataFim)";
                SqlCommand sc = new SqlCommand(cmd, cx);

                sc.Parameters.AddWithValue("@CursoId", historico.CursoId);
                sc.Parameters.AddWithValue("@TraineeId", historico.TraineeId);
                sc.Parameters.AddWithValue("@DataInicio", historico.DataInicio.ToString("yyyy-MM-dd"));
                sc.Parameters.AddWithValue("@DataFim", historico.DataFim.ToString("yyyy-MM-dd"));

                cx.Open();
                sc.ExecuteNonQuery();

            }
            finally
            {
                cx.Close();
            }
        }

        public List<Historico> BuscandoHistorico()
        {
            SqlConnection cx = new SqlConnection(ConnectionString);
            try
            {
                string cmd = "select * from Historico";
                SqlCommand sc = new SqlCommand(cmd, cx);
                
                cx.Open();

                SqlDataReader sdr = sc.ExecuteReader();

                List<Historico> historicos = new List<Historico>();
                while (sdr.Read())
                {
                    Historico h = new Historico()
                    {
                        Id = Convert.ToInt32(sdr["Id"]),
                        CursoId = Convert.ToInt32(sdr["CursoId"]),
                        TraineeId = Convert.ToInt32(sdr["TraineeId"]),
                        DataInicio = Convert.ToDateTime(sdr["DataInicio"]),
                        DataFim = Convert.ToDateTime(sdr["DataFim"]),

                        curso = new CursoADO().BuscarCursoPorID(Convert.ToInt32(sdr["CursoId"])),
                        trainee = new TraineeADO().BuscarTraineePorID(Convert.ToInt32(sdr["TraineeId"]))
                    };

                    historicos.Add(h);
                }
                
                return historicos;
            }
            finally
            {
                cx.Close();
            }
        }
    }
}
