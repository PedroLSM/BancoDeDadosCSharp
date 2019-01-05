using BancoDeDados;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infraestrutura.RepositoriosEF
{
    public class TraineeRepositorioEF
    {
        EstagioContext ctx;

        public TraineeRepositorioEF()
        {
            ctx = new EstagioContext();

            if (!ctx.Trainee.Any())
            {
                List<Trainee> trainees = new List<Trainee>
                {
                    new Trainee("Pedro Lucas"),
                    new Trainee("Alisson Jardel"),
                    new Trainee("Gustavo Sampaio"),
                    new Trainee("Nikolas Medeiros")
                };

                InserirTrainees(trainees);
            }
        }

        public Trainee BuscarTraineePorID(int id)
        {
            var trainee = ctx.Trainee.FirstOrDefault(c => c.Id == id);

            return trainee;
        }

        public List<Trainee> BuscarTrainees()
        {
            var trainee = ctx.Trainee.ToList();

            return trainee;
        }

        public void InserirTrainee(Trainee trainee)
        {
            ctx.Trainee.Add(trainee);

            ctx.SaveChanges();
        }

        public void InserirTrainees(List<Trainee> trainees)
        {
            ctx.Trainee.AddRange(trainees);

            ctx.SaveChanges();
        }

        public void DeletarTraineePorID(int id)
        {
            var result = BuscarTraineePorID(id);

            if (result != null)
            {
                ctx.Trainee.Remove(result);
                ctx.SaveChanges();
                return;
            }

            Console.WriteLine("ID Não Encontrado");
        }

        public void AtualizarTrainee(Trainee updateTrainee)
        {
            ctx.Trainee.Attach(updateTrainee);

            ctx.Entry(updateTrainee).Property(c => c.Nome).IsModified = true;

            ctx.SaveChanges();
        }
    }
}
