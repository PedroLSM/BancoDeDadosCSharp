using BancoDeDados;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infraestrutura.RepositoriosEF
{

    public class CursoRepositorioEF
    {
        EstagioContext ctx;

        public CursoRepositorioEF()
        {
            ctx = new EstagioContext();

            if (!ctx.Curso.Any())
            {
                List<Curso> cursos = new List<Curso>
                {
                    new Curso("C# Fundamentals with Visual Studio 2015", "Scott Alen", 300),
                    new Curso("Desenvolvimento Web", "Shawn Wildermuth", 200),
                    new Curso("Programação Java - Iniciante", "Guanabara", 350),
                    new Curso("Programação Java - Intermediario", "Loiane", 300)
                };

                InserirCursos(cursos);
            }

        }

        public Curso BuscarCursoPorID(int id)
        {
            var curso = ctx.Curso.FirstOrDefault(c => c.Id == id);

            return curso;
        }

        public List<Curso> BuscarCursos()
        {
            var cursos = ctx.Curso.ToList();

            return cursos;
        }

        public void InserirCurso(Curso curso)
        {
            ctx.Curso.Add(curso);

            ctx.SaveChanges();
        }

        public void InserirCursos(List<Curso> cursos)
        {
            ctx.Curso.AddRange(cursos);

            ctx.SaveChanges();
        }

        public void DeletarCursoPorID(int id)
        {
            var result = BuscarCursoPorID(id);

            if (result != null)
            {
                ctx.Curso.Remove(result);
                ctx.SaveChanges();
                return;
            }

            Console.WriteLine("ID Não Encontrado");
        }

        public void AtualizarCurso(Curso updateCurso)
        {
            ctx.Curso.Attach(updateCurso);

            ctx.Entry(updateCurso).Property(c => c.Nome).IsModified = true;
            ctx.Entry(updateCurso).Property(c => c.Autor).IsModified = true;
            ctx.Entry(updateCurso).Property(c => c.CargaHoraria).IsModified = true;

            ctx.SaveChanges();
        }
    }
}
