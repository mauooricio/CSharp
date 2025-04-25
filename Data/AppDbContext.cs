using Microsoft.EntityFrameworkCore;
using PetShopCSharp.Models;

namespace PetShopCSharp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Instrutor> Instrutores { get; set; }
        public DbSet<Voluntario> Voluntarios { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Apoiador> Apoiadores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<EventoInstitucional> EventosInstitucionais { get; set; }
        public DbSet<InscricaoEvento> InscricoesEvento { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TPH inheritance for Usuario
            modelBuilder.Entity<Usuario>()
                .HasDiscriminator<string>("Role")
                .HasValue<Administrador>("Admin")
                .HasValue<Instrutor>("Instrutor")
                .HasValue<Voluntario>("Voluntario")
                .HasValue<Participante>("Participante")
                .HasValue<Apoiador>("Apoiador");

            // Instrutor -> EventoInstitucional (organizador)
            modelBuilder.Entity<EventoInstitucional>()
                .HasOne(e => e.Organizador)
                .WithMany(i => i.EventosOrganizados)
                .HasForeignKey(e => e.OrganizadorId)
                .OnDelete(DeleteBehavior.Restrict);

            // InscricaoEvento -> Participante
            modelBuilder.Entity<InscricaoEvento>()
                .HasOne(i => i.Participante)
                .WithMany(p => p.Inscricoes)
                .HasForeignKey(i => i.ParticipanteId)
                .OnDelete(DeleteBehavior.Restrict);

            // InscricaoEvento -> EventoInstitucional
            modelBuilder.Entity<InscricaoEvento>()
                .HasOne(i => i.Evento)
                .WithMany(e => e.Inscricoes)
                .HasForeignKey(i => i.EventoInstitucionalId)
                .OnDelete(DeleteBehavior.Cascade);

            // Atividade -> Projeto
            modelBuilder.Entity<Atividade>()
                .HasOne(a => a.Projeto)
                .WithMany(p => p.Atividades)
                .HasForeignKey(a => a.ProjetoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Atividade -> EventoInstitucional (opcional)
            modelBuilder.Entity<Atividade>()
                .HasOne(a => a.EventoInstitucional)
                .WithMany(e => e.Atividades)
                .HasForeignKey(a => a.EventoInstitucionalId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relatorio -> Projeto
            modelBuilder.Entity<Relatorio>()
                .HasOne(r => r.Projeto)
                .WithMany(p => p.Relatorios)
                .HasForeignKey(r => r.ProjetoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relatorio -> Administrador (avaliador)
            modelBuilder.Entity<Relatorio>()
                .HasOne(r => r.AvaliadoPor)
                .WithMany()
                .HasForeignKey(r => r.AvaliadoPorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Publicacao -> Usuario
            modelBuilder.Entity<Publicacao>()
                .HasOne(pub => pub.Autor)
                .WithMany(u => u.Publicacoes)
                .HasForeignKey(pub => pub.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Notificacao -> Usuario
            modelBuilder.Entity<Notificacao>()
                .HasOne(n => n.Destinatario)
                .WithMany(u => u.Notificacoes)
                .HasForeignKey(n => n.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}