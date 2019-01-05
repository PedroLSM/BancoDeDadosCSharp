using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    public class TraineeADO
    {
        private string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EstagioDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void InserirTrainee(Trainee trainee)
        {
            SqlConnection cx = new SqlConnection(ConnectionString);
            try
            {
                string cmd = "insert into Trainee (Nome) values (@Nome)";
                SqlCommand sc = new SqlCommand(cmd, cx);

                sc.Parameters.AddWithValue("@Nome", trainee.Nome);

                cx.Open();
                sc.ExecuteNonQuery();

            }
            finally
            {
                cx.Close();
            }
            
        }

        public Trainee BuscarTraineePorID(int id)
        {
            SqlConnection cx = new SqlConnection(ConnectionString);
            try
            {


                string cmd = "select * from Trainee where Id = @id";
                SqlCommand sc = new SqlCommand(cmd, cx);
                sc.Parameters.AddWithValue("@id", id);

                cx.Open();

                SqlDataReader sdr = sc.ExecuteReader();

                Trainee t = new Trainee();
                if (sdr.Read())
                {
                    t.Id = Convert.ToInt32(sdr["Id"]);
                    t.Nome = sdr["Nome"].ToString();
                }

                return t;
            }
            finally
            {
                cx.Close();
            }
        }

        public List<Trainee> BuscarTrainee()
        {
            SqlConnection cx = new SqlConnection(ConnectionString);
            try
            {


                string cmd = "select * from Trainee";
                SqlCommand sc = new SqlCommand(cmd, cx);


                cx.Open();

                SqlDataReader sdr = sc.ExecuteReader();

                List<Trainee> trainee = new List<Trainee>();
                while (sdr.Read())
                {
                    Trainee t = new Trainee()
                    {
                        Id = Convert.ToInt32(sdr["id"]),
                        Nome = sdr["Nome"].ToString()
                    };

                    trainee.Add(t);
                }

                return trainee;
            }
            finally
            {
                cx.Close();
            }
        }

        public void DeletarTrainnePorID(int id)
        {
            SqlConnection cx = new SqlConnection(ConnectionString);
            try
            {
                string cmd = "delete from Trainee where Id = @id";
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

        public void AtualizarTraineePorID(int id, Trainee c)
        {
            SqlConnection cx = new SqlConnection(ConnectionString);
            try
            {
                string cmd = "update Trainee set Nome = @newName where Id = @id";
                SqlCommand sc = new SqlCommand(cmd, cx);

                sc.Parameters.AddWithValue("@id", id);
                sc.Parameters.AddWithValue("@newName", c.Nome);
                
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
