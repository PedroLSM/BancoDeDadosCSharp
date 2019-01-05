using BancoDeDados;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.RepositoriosEF
{
    public class EstagioContext : DbContext
    {
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<Historico> Historico { get; set; }

        public EstagioContext() : base("name=EstagioDB")
        {
        }
    }
}
