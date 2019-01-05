using Dominio;
using Infraestrutura;
using Infraestrutura.RepositoriosEF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BancoDeDados
{
    class Program
    {
        static void Main(string[] args)
        {
            // ===============================
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EstagioContext>());

            CursoRepositorioEF cursodb = new CursoRepositorioEF();
            TraineeRepositorioEF traineedb = new TraineeRepositorioEF();

            BuscarTodosOsCursosEF(cursodb);

            // BuscarCursoPorIdEF(cursodb);
            // InserirCursoEF(cursodb);
            // AtualizarCursoEF(cursodb);
            // DeletarCursoPorIdEF(cursodb);

            Console.WriteLine("");
            Console.WriteLine("==============================");

            BuscarTodosOsTraineesEF(traineedb);

            // BuscarTraineePorIdEF(traineedb);
            // InserirTraineeEF(traineedb);
            // AtualizarTraineeEF(traineedb);
            // DeletarTraineePorIdEF(traineedb);

            // TestesDoRepositorioSemEF();

            Console.ReadKey();

        }


        // UTILIZANDO SEM ENTITY
        // =========================================================================

        private static void TestesDoRepositorioSemEF()
        {
            //===============================

            CursoADO cursoBD = new CursoADO();
            TraineeADO traineeBD = new TraineeADO();
            HistoricoADO historicoBD = new HistoricoADO();

            // ===============================
            // Curso

            // InserindoCurso(cursoBD);
            // AtualizandoCurso(cursoBD);

            // DeletandoCursoPorID(cursoBD);

            MostrandoCursos(cursoBD);

            //BuscandoCursoPorID(cursoBD);

            //Console.WriteLine("*****");
            //CargaMaiorOuIgual300(cursoBD);

            //Console.WriteLine("*****");
            //CargaMenorQue300(cursoBD);

            //Console.WriteLine("*****");
            //OrdenadoPorNome(cursoBD);
            //Console.WriteLine();

            //Console.WriteLine("*****");
            //CursosDeScott(cursoBD);



            Console.WriteLine();
            // ===============================
            // Trainne

            //InserindoTrainee(traineeBD);

            // AtualizarTrainee(traineeBD);

            // BuscandoTraineePorID(traineeBD);

            // DeletandoTraineePorID(traineeBD);

            MostrandoTrainees(traineeBD);

            // ===============================
            //  Historico

            //InserindoHistorico(historicoBD);

            var historicos = historicoBD.BuscandoHistorico();

            //foreach (var h in historicos)
            //{
            //    Console.WriteLine(h);
            //}

            Console.WriteLine();

            foreach (var h in historicos)
            {
                Console.WriteLine(h.HistoricoDetalhado());
            }
            Console.WriteLine();
        }

        // CURSOS COM ENTITY FRAMEWORK
        // =========================================================================

        private static void BuscarCursoPorIdEF(CursoRepositorioEF cursodb)
        {
            Console.WriteLine();

            Curso curso = cursodb.BuscarCursoPorID(1);

            Console.WriteLine(curso);
        }

        private static void BuscarTodosOsCursosEF(CursoRepositorioEF cursodb)
        {
            Console.WriteLine();
            var cursos = cursodb.BuscarCursos();

            foreach (var c in cursos)
            {
                Console.WriteLine(c);
            }
        }

        private static void InserirCursoEF(CursoRepositorioEF cursodb)
        {
            Curso newCurso = new Curso()
            {
                Nome = "LINQ Fundamentals with C# 6.0",
                Autor = "Scott Allen",
                CargaHoraria = 300
            };

            cursodb.InserirCurso(newCurso);
        }

        private static void AtualizarCursoEF(CursoRepositorioEF cursodb)
        {
            Console.WriteLine();

            Curso updateCurso = cursodb.BuscarCursoPorID(1);

            updateCurso.Nome = "C# Fundamentals with Visual Studio 2015";
            cursodb.AtualizarCurso(updateCurso);

            Console.WriteLine();
        }

        private static void DeletarCursoPorIdEF(CursoRepositorioEF cursodb)
        {
            Console.WriteLine();
            cursodb.DeletarCursoPorID(2);
        }

        // TRAINEE COM ENTITY FRAMEWORK
        // =========================================================================

        private static void BuscarTraineePorIdEF(TraineeRepositorioEF traineedb)
        {
            Console.WriteLine();

            Trainee trainee = traineedb.BuscarTraineePorID(1);

            Console.WriteLine(trainee);
        }

        private static void BuscarTodosOsTraineesEF(TraineeRepositorioEF traineedb)
        {
            Console.WriteLine();
            var trainees = traineedb.BuscarTrainees();

            foreach (var t in trainees)
            {
                Console.WriteLine(t);
            }
        }

        private static void InserirTraineeEF(TraineeRepositorioEF traineedb)
        {
            Trainee newTrainee = new Trainee("Pedro Lucas");

            traineedb.InserirTrainee(newTrainee);
        }

        private static void AtualizarTraineeEF(TraineeRepositorioEF traineedb)
        {
            Console.WriteLine();

            Trainee updateTrainee = traineedb.BuscarTraineePorID(1);

            updateTrainee.Nome = "Pedro Matias";
            traineedb.AtualizarTrainee(updateTrainee);

            Console.WriteLine();
        }

        private static void DeletarTraineePorIdEF(TraineeRepositorioEF traineedb)
        {
            Console.WriteLine();
            traineedb.DeletarTraineePorID(1);
        }


        // CURSOS SEM ENTITY FRAMEWORK - FUNÇÕES
        // =========================================================================

        private static void CursosDeScott(CursoADO cursoBD)
        {
            List<Curso> cursos = cursoBD.BuscarCurso();

            var query = cursos.Where(c => c.Autor == "Scott Allen")
                                .Select(c => c.Nome + " - " + c.Autor);

            foreach (var curso in query)
            {
                Console.WriteLine(curso);
            }
        }

        private static void OrdenadoPorNome(CursoADO cursoBD)
        {
            List<Curso> cursos = cursoBD.BuscarCurso();

            // Ascendente
            var query = cursos.OrderBy(c => c.Autor)
                                .Select(c => c.Nome + " - " + c.Autor);

            foreach (var curso in query)
            {
                Console.WriteLine(curso);
            }

            Console.WriteLine("*****");

            // Descendente
            var query2 = cursos.OrderByDescending(c => c.Autor)
                                .Select(c => c.Nome + " - " + c.Autor);

            foreach (var curso in query2)
            {
                Console.WriteLine(curso);
            }
        }

        private static void CargaMenorQue300(CursoADO cursoBD)
        {
            List<Curso> cursos = cursoBD.BuscarCurso();

            var query = cursos.Where(c => c.CargaHoraria < 300)
                                .Select(c => c.Nome + " - " + c.CargaHoraria);
            foreach (var curso in query)
            {
                Console.WriteLine(curso);
            }
        }

        private static void CargaMaiorOuIgual300(CursoADO cursoBD)
        {
            List<Curso> cursos = cursoBD.BuscarCurso();

            var query = cursos.Where(c => c.CargaHoraria >= 300)
                                .Select(c => c.Nome + " - " + c.CargaHoraria);

            foreach (var curso in query)
            {
                Console.WriteLine(curso);
            }
        }

        // HISTORICO SEM ENTITY FRAMEWORK
        // =========================================================================

        private static void InserindoHistorico(HistoricoADO historicoBD)
        {
            List<Historico> historico = new List<Historico>
            {
                new Historico(2, 1, new DateTime(2018, 8, 13), new DateTime(2018, 9, 8)),
                new Historico(1, 1, new DateTime(2018, 9, 9), new DateTime(2018, 9, 11)),
                new Historico(3, 1, new DateTime(2018, 9, 12), new DateTime())
            };

            foreach (Historico ht in historico)
            {
                historicoBD.InserirHistorico(ht);
            }
        }

        // TRAINEE SEM ENTITY FRAMEWORK
        // =========================================================================

        private static void MostrandoTrainees(TraineeADO traineeBD)
        {
            List<Trainee> trainees = traineeBD.BuscarTrainee();
            foreach (Trainee t in trainees)
            {
                Console.WriteLine(t);
            }
        }

        private static void InserindoTrainee(TraineeADO traineeBD)
        {
            List<Trainee> trainee = new List<Trainee>
            {
                new Trainee("Pedro Lucas"),
                new Trainee("Alisson Jardel"),
                new Trainee("Gustavo Sampaio"),
                new Trainee("Nikolas Medeiros")
            };

            foreach (Trainee t in trainee)
            {
                traineeBD.InserirTrainee(t);
            }
        }

        private static void BuscandoTraineePorID(TraineeADO traineeBD)
        {
            Trainee t2 = traineeBD.BuscarTraineePorID(2);
            Console.WriteLine(t2);
            Console.WriteLine();
        }

        private static void AtualizarTrainee(TraineeADO traineeBD)
        {
            traineeBD.AtualizarTraineePorID(2, new Trainee("Alisson Belchior"));
        }

        private static void DeletandoTraineePorID(TraineeADO traineeBD)
        {
            traineeBD.DeletarTrainnePorID(5);
            traineeBD.DeletarTrainnePorID(6);
            traineeBD.DeletarTrainnePorID(7);
            traineeBD.DeletarTrainnePorID(8);
        }

        // CURSOS SEM ENTITY FRAMEWORK
        // =========================================================================

        private static void MostrandoCursos(CursoADO cursoBD)
        {
            List<Curso> cursos = cursoBD.BuscarCurso();
            foreach (Curso c in cursos)
            {
                Console.WriteLine(c.ToString());
            }
        }

        private static void InserindoCurso(CursoADO cursoBD)
        {
            List<Curso> curso = new List<Curso>
            {
                new Curso("C# Fundamentals with Visual Studio 2015", "Scott Alen", 300),
                new Curso("Desenvolvimento Web", "Shawn Wildermuth", 200),
                new Curso("Programação Java - Iniciante", "Guanabara", 350),
                new Curso("Programação Java - Intermediario", "Loiane", 300)
            };

            foreach (Curso c in curso)
            {
                cursoBD.InserirCurso(c);
            }

            cursoBD.InserirCurso(new Curso("Programação Java - Intermediario", "Loiane", 300));
            Console.WriteLine();
        }

        private static void BuscandoCursoPorID(CursoADO cursoBD)
        {
            Curso c2 = cursoBD.BuscarCursoPorID(2);
            Console.WriteLine(c2);
            Console.WriteLine();
        }

        private static void AtualizandoCurso(CursoADO cursoBD)
        {
            Curso curso = new Curso("C# Fundamentals with Visual Studio 2015", "Scott Allen", 300);
            cursoBD.AtualizarCursoPorID(1, curso);
        }

        private static void DeletandoCursoPorID(CursoADO cursoBD)
        {
            Console.WriteLine();
            cursoBD.DeletarCursoPorID(1003);
        }


    }
}
