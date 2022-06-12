using System.Data.Entity;
using Agendamento.Models;

namespace Agendamento.DataAccess
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Equipe_Integrante> Equipe_Integrantes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Usuario_Agendamento> Usuario_Agendamento { get; set; }
        public virtual DbSet<Usuario_Equipe> Usuario_Equipes { get; set; }
        public virtual DbSet<Usuario_Plano> Usuario_Plano { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Usuario_Agendamento)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.Usuario_Id_Usuario)
                .WillCascadeOnDelete(false); 
            
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Usuario_Equipe)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.Usuario_Id_Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Usuario_Plano)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.Usuario_Id_Usuario)
                .WillCascadeOnDelete(false); 
            
            modelBuilder.Entity<Usuario_Equipe>()
                .HasMany(e => e.Equipe_Integrante)
                .WithRequired(e => e.Usuario_Equipe)
                .HasForeignKey(e => e.Usuario_Equipe_Id_Usuario_Equipe)
                .WillCascadeOnDelete(false);
        }
    }
}
