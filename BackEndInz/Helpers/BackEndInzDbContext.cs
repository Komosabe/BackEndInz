﻿using BackEndInz.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BackEndInz.Helpers
{
    public class BackEndInzDbContext : DbContext
    {
        public BackEndInzDbContext(DbContextOptions<BackEndInzDbContext> options) : base(options)
        {

        }

        // DbSets for all entities
        public DbSet<Board> boards { get; set; }
        public DbSet<Column> columns { get; set; }
        public DbSet<Label> labels { get; set; }
        public DbSet<Note> notes { get; set; }
        public DbSet<RoleInApplication> roleInApplications { get; set; }
        public DbSet<User> users { get; set; }


        // Additional configurations for entity relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// BoardLabel
            //modelBuilder.Entity<Board>()
            //    .HasMany(e => e.Labels)
            //    .WithMany(e => e.Boards)
            //    .UsingEntity(
            //        "BoardLabel",
            //        l => l.HasOne(typeof(Label)).WithMany().HasForeignKey("LabelsId").HasPrincipalKey(nameof(Label.Id)),
            //        r => r.HasOne(typeof(Board)).WithMany().HasForeignKey("BoardsId").HasPrincipalKey(nameof(Board.Id)),
            //        j => j.HasKey("BoardsId", "LabelsId"));

            //// NoteLabel
            //modelBuilder.Entity<Note>()
            //    .HasMany(e => e.Labels)
            //    .WithMany(e => e.Notes)
            //    .UsingEntity(
            //        "NoteLabel",
            //        l => l.HasOne(typeof(Label)).WithMany().HasForeignKey("LabelsId").HasPrincipalKey(nameof(Label.Id)),
            //        r => r.HasOne(typeof(Note)).WithMany().HasForeignKey("NotesId").HasPrincipalKey(nameof(Note.Id)),
            //        j => j.HasKey("NotesId", "LabelsId"));

            modelBuilder.Entity<Board>()
                .HasOne(b => b.Label)
                .WithOne(l => l.Board)
                .HasForeignKey<Label>(l => l.BoardId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Note>()
                .HasOne(n => n.Label)
                .WithOne(l => l.Note)
                .HasForeignKey<Label>(l => l.NoteId)
                .OnDelete(DeleteBehavior.Cascade);

            //BoardUser
            modelBuilder.Entity<Board>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Boards)
                .UsingEntity(
                    "BoardUser",
                    l => l.HasOne(typeof(User)).WithMany().HasForeignKey("UsersId").HasPrincipalKey(nameof(User.Id)),
                    r => r.HasOne(typeof(Board)).WithMany().HasForeignKey("BoardsId").HasPrincipalKey(nameof(Board.Id)),
                    j => j.HasKey("BoardsId", "UsersId"));

            // UserNote
            modelBuilder.Entity<User>()
                .HasMany(e => e.Notes)
                .WithMany(e => e.Users)
                .UsingEntity(
                    "UserNote",
                    l => l.HasOne(typeof(Note)).WithMany().HasForeignKey("NotesId").HasPrincipalKey(nameof(Note.Id)),
                    r => r.HasOne(typeof(User)).WithMany().HasForeignKey("UsersId").HasPrincipalKey(nameof(User.Id)),
                    j => j.HasKey("UsersId", "NotesId"));


            // Configuration For Column
            modelBuilder.Entity<Column>()
                .HasOne(c => c.Board)
                .WithMany(t => t.Columns)
                .HasForeignKey(c => c.BoardId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration For Note
            modelBuilder.Entity<Note>()
                .HasOne(n => n.Column)
                .WithMany(c => c.Notes)
                .HasForeignKey(n => n.ColumnId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Column>()
                .HasMany(c => c.Notes)
                .WithOne(n => n.Column)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Note>()
            //    .HasOne(n => n.Label)
            //    .WithOne(l => l.Note)
            //    .HasForeignKey<Label>(l => l.NoteId)
            //    .OnDelete(DeleteBehavior.Cascade);

            // Konfiguracja między Board a Label
            //modelBuilder.Entity<Board>()
            //    .HasOne(b => b.Label)
            //    .WithOne(l => l.Board)
            //    .HasForeignKey<Label>(l => l.BoardId)
            //    .OnDelete(DeleteBehavior.Cascade);


            // Konfiguracja między Note a Label
            modelBuilder.Entity<Note>()
                .HasOne(n => n.Label)
                .WithOne(l => l.Note)
                .HasForeignKey<Label>(l => l.NoteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.Label)
                .WithOne(l => l.Note)
                .HasForeignKey<Label>(l => l.NoteId)
                .OnDelete(DeleteBehavior.SetNull);

            // Usuwam Label -> LabelId dla Note i Board = Null
            modelBuilder.Entity<Label>()
                .HasOne(l => l.Board)
                .WithOne(b => b.Label)
                .HasForeignKey<Board>(b => b.LabelId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Label>()
                .HasOne(l => l.Note)
                .WithOne(n => n.Label)
                .HasForeignKey<Note>(n => n.LabelId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
