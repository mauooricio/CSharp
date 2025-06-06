﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetShopCSharp.Data;

#nullable disable

namespace PetShopCSharp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PetShopCSharp.Models.Atividade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventoInstitucionalId")
                        .HasColumnType("int");

                    b.Property<int>("Progresso")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventoInstitucionalId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Atividades");
                });

            modelBuilder.Entity("PetShopCSharp.Models.EventoInstitucional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescricaoDetalhada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InscricoesAbertas")
                        .HasColumnType("bit");

                    b.Property<string>("Local")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizadorId")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VagasDisponiveis")
                        .HasColumnType("int");

                    b.Property<int?>("VoluntarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizadorId");

                    b.HasIndex("VoluntarioId");

                    b.ToTable("EventosInstitucionais");
                });

            modelBuilder.Entity("PetShopCSharp.Models.InscricaoEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataInscricao")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventoInstitucionalId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipanteId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventoInstitucionalId");

                    b.HasIndex("ParticipanteId");

                    b.ToTable("InscricoesEvento");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Notificacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mensagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Notificacoes");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResponsavelId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResponsavelId");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Publicacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Publicacoes");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Relatorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AvaliadoPorId")
                        .HasColumnType("int");

                    b.Property<string>("Conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AvaliadoPorId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Relatorios");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Role").HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PetShopCSharp.Models.Administrador", b =>
                {
                    b.HasBaseType("PetShopCSharp.Models.Usuario");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Apoiador", b =>
                {
                    b.HasBaseType("PetShopCSharp.Models.Usuario");

                    b.HasDiscriminator().HasValue("Apoiador");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Instrutor", b =>
                {
                    b.HasBaseType("PetShopCSharp.Models.Usuario");

                    b.HasDiscriminator().HasValue("Instrutor");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Participante", b =>
                {
                    b.HasBaseType("PetShopCSharp.Models.Usuario");

                    b.HasDiscriminator().HasValue("Participante");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Voluntario", b =>
                {
                    b.HasBaseType("PetShopCSharp.Models.Usuario");

                    b.HasDiscriminator().HasValue("Voluntario");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Atividade", b =>
                {
                    b.HasOne("PetShopCSharp.Models.EventoInstitucional", "EventoInstitucional")
                        .WithMany("Atividades")
                        .HasForeignKey("EventoInstitucionalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PetShopCSharp.Models.Projeto", "Projeto")
                        .WithMany("Atividades")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventoInstitucional");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("PetShopCSharp.Models.EventoInstitucional", b =>
                {
                    b.HasOne("PetShopCSharp.Models.Instrutor", "Organizador")
                        .WithMany("EventosOrganizados")
                        .HasForeignKey("OrganizadorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PetShopCSharp.Models.Voluntario", null)
                        .WithMany("EventosAuxiliados")
                        .HasForeignKey("VoluntarioId");

                    b.Navigation("Organizador");
                });

            modelBuilder.Entity("PetShopCSharp.Models.InscricaoEvento", b =>
                {
                    b.HasOne("PetShopCSharp.Models.EventoInstitucional", "Evento")
                        .WithMany("Inscricoes")
                        .HasForeignKey("EventoInstitucionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetShopCSharp.Models.Participante", "Participante")
                        .WithMany("Inscricoes")
                        .HasForeignKey("ParticipanteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Participante");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Notificacao", b =>
                {
                    b.HasOne("PetShopCSharp.Models.Usuario", "Destinatario")
                        .WithMany("Notificacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destinatario");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Projeto", b =>
                {
                    b.HasOne("PetShopCSharp.Models.Usuario", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Responsavel");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Publicacao", b =>
                {
                    b.HasOne("PetShopCSharp.Models.Usuario", "Autor")
                        .WithMany("Publicacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Relatorio", b =>
                {
                    b.HasOne("PetShopCSharp.Models.Administrador", "AvaliadoPor")
                        .WithMany()
                        .HasForeignKey("AvaliadoPorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PetShopCSharp.Models.Projeto", "Projeto")
                        .WithMany("Relatorios")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AvaliadoPor");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("PetShopCSharp.Models.EventoInstitucional", b =>
                {
                    b.Navigation("Atividades");

                    b.Navigation("Inscricoes");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Projeto", b =>
                {
                    b.Navigation("Atividades");

                    b.Navigation("Relatorios");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Usuario", b =>
                {
                    b.Navigation("Notificacoes");

                    b.Navigation("Publicacoes");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Instrutor", b =>
                {
                    b.Navigation("EventosOrganizados");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Participante", b =>
                {
                    b.Navigation("Inscricoes");
                });

            modelBuilder.Entity("PetShopCSharp.Models.Voluntario", b =>
                {
                    b.Navigation("EventosAuxiliados");
                });
#pragma warning restore 612, 618
        }
    }
}
