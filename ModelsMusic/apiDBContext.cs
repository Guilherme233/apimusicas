using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace apimusicas.ModelsMusic
{
    public partial class apiDBContext : DbContext
    {
        public apiDBContext()
        {
        }

        public apiDBContext(DbContextOptions<apiDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCantor> TbCantors { get; set; } = null!;
        public virtual DbSet<TbMusica> TbMusicas { get; set; } = null!;
        public virtual DbSet<TbMusicaCantor> TbMusicaCantors { get; set; } = null!;
        public virtual DbSet<TbProdutor> TbProdutors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user id=root;password=Matheus3146!;database=apiDB", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<TbCantor>(entity =>
            {
                entity.HasKey(e => e.IdCantor)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<TbMusica>(entity =>
            {
                entity.HasKey(e => e.IdMusica)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<TbMusicaCantor>(entity =>
            {
                entity.HasKey(e => e.IdMusicaCantor)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.IdCantorNavigation)
                    .WithMany(p => p.TbMusicaCantors)
                    .HasForeignKey(d => d.IdCantor)
                    .HasConstraintName("tb_musica_cantor_ibfk_2");

                entity.HasOne(d => d.IdMusicaNavigation)
                    .WithMany(p => p.TbMusicaCantors)
                    .HasForeignKey(d => d.IdMusica)
                    .HasConstraintName("tb_musica_cantor_ibfk_1");
            });

            modelBuilder.Entity<TbProdutor>(entity =>
            {
                entity.HasKey(e => e.IdProdutor)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.IdMusicaNavigation)
                    .WithMany(p => p.TbProdutors)
                    .HasForeignKey(d => d.IdMusica)
                    .HasConstraintName("tb_produtor_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
