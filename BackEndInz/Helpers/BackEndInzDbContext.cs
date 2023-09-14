using BackEndInz.Entities;
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
            // BoardLabel
            modelBuilder.Entity<Board>()
                .HasMany(e => e.Labels)
                .WithMany(e => e.Boards)
                .UsingEntity(
                    "BoardLabel",
                    l => l.HasOne(typeof(Label)).WithMany().HasForeignKey("LabelsId").HasPrincipalKey(nameof(Label.Id)),
                    r => r.HasOne(typeof(Board)).WithMany().HasForeignKey("BoardsId").HasPrincipalKey(nameof(Board.Id)),
                    j => j.HasKey("BoardsId", "LabelsId"));

            // NoteLabel
            modelBuilder.Entity<Note>()
                .HasMany(e => e.Labels)
                .WithMany(e => e.Notes)
                .UsingEntity(
                    "NoteLabel",
                    l => l.HasOne(typeof(Label)).WithMany().HasForeignKey("LabelsId").HasPrincipalKey(nameof(Label.Id)),
                    r => r.HasOne(typeof(Note)).WithMany().HasForeignKey("NotesId").HasPrincipalKey(nameof(Note.Id)),
                    j => j.HasKey("NotesId", "LabelsId"));
            
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


            //// Configuration For Column
            //modelBuilder.Entity<Column>()
            //    .HasOne(c => c.Board)
            //    .WithMany(t => t.Columns)
            //    .HasForeignKey(c => c.BoardId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //// Configuration for Note
            //modelBuilder.Entity<Note>()
            //    .HasOne(n => n.CreatedBy)
            //    .WithMany(u => u.CreatedNotes)
            //    .HasForeignKey(n => n.CreatedById)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Note>()
            //    .HasOne(n => n.Column)
            //    .WithMany(c => c.Notes)
            //    .HasForeignKey(n => n.ColumnId)
            //    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
