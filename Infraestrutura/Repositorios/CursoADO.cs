using System;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    public class CursoADO
    {
        private string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EstagioDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void InserirCurso(Curso curso)
        {
            SqlConnection cx = new SqlConnection(ConnectionString);
            try
            {
                string cmd = "insert into Curso (Nome, Autor, CargaHoraria) values (@Nome, @Autor, @Carga)";
                SqlCommand sc = new SqlCommand(cmd, cx);

                sc.Parameters.AddWithValue("@Nome", curso.Nome);
                sc.Parameters.AddWithValue("@Autor", curso.Autor);
                sc.Parameters.AddWithValue("@Carga", curso.CargaHoraria);

                cx.Open();

                sc.ExecuteNonQuery();

            }
            finally
            {
                cx.Close();
            }
        }
        
        public Curso BuscarCursoPorID(int id)
        {
            SqlConnection cx = new SqlConnection(ConnectionString);
            try
            {


                string cmd = "select * from Cursos where Id = @id";
                SqlCommand sc = new SqlCommand(cmd, cx);
                sc.Parameters.AddWithValue("@id", id);

                cx.Open();

                SqlDataReader sdr = sc.ExecuteReader();

                Curso c = new Curso();
                if(sdr.Read())
                {
                    c.Id = Convert.ToInt32(sdr["Id"]);
                    c.Nome = sdr["Nome"].ToString();
                    c.Autor = sdr["Autor"].ToString();
                    c.CargaHoraria = Convert.ToInt32(sdr["CargaHoraria"]);
                }
                Console.WriteLine();
            
                return c;
            }
            finally
            {
                cx.Close();
            }
        }

        public List<Curso> BuscarCurso()
        {
            SqlConnection cx = new SqlConnection(ConnectionString);
            try
            {


                string cmd = "select * from Curso";
                SqlCommand sc = new SqlCommand(cmd, cx);


                cx.Open();

                SqlDataReader sdr = sc.ExecuteReader();

                List<Curso> cursos = new List<Curso>();
                while (sdr.Read())
                {
                    Curso c = new Curso
                    {
                        Id = Convert.ToInt32(sdr["Id"]),
                        Nome = sdr["Nome"].ToString(),
                        Autor = sdr["Autor"].ToString(),
                        CargaHoraria = Convert.ToInt32(sdr["CargaHoraria"])
                    };

                    cursos.Add(c);
                }

                return cursos;
            }
            finally
            {
                cx.Close();
            }
        }

        public void DeletarCursoPorID(int id)
        {
            SqlConnection cx = new SqlConnection(ConnectionString);
            try
            {
                string cmd = "delete from Curso where Id = @id";
                SqlCommand sc = new SqlCommand(cmd, cx);

                sc.Parameters.AddWithValue("@id", id);

                cx.Open();

                sc.ExecuteNonQuery();
                
            }
            finally
            {
                cx.Close();
            }
        }

        public void AtualizarCursoPorID(int id, Curso c)
        {
            SqlConnection cx = new SqlConnection(ConnectionString);
            try
            {
                string cmd = "update Curso set Nome = @newName, Autor = @newAutor, CargaHoraria = @newCarga where Id = @id";
                SqlCommand sc = new SqlCommand(cmd, cx);

                sc.Parameters.AddWithValue("@id", id);
                sc.Parameters.AddWithValue("@newName", c.Nome);
                sc.Parameters.AddWithValue("@newAutor", c.Autor);
                sc.Parameters.AddWithValue("@newCarga", c.CargaHoraria);

                cx.Open();

                sc.ExecuteNonQuery();

            }
            finally
            {
                cx.Close();
            }
        }

    }
}
