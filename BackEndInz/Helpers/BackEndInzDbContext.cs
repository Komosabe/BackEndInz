using BackEndInz.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEndInz.Helpers
{
    public class BackEndInzDbContext : DbContext
    {
        public BackEndInzDbContext(DbContextOptions<BackEndInzDbContext> options) : base(options)
        {

        }

        // DbSets for all entities
        public DbSet<Board> boards { get; set; }
        public DbSet<BoardLabel> boardLabels { get; set; }
        public DbSet<BoardUser> boardUsers { get; set; }
        public DbSet<Column> columns { get; set; }
        public DbSet<Label> labels { get; set; }
        public DbSet<Note> notes { get; set; }
        public DbSet<NoteLabel> noteLabels { get; set; }
        public DbSet<RoleInApplication> roleInApplications { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserNote> userNotes { get; set; }


        // Additional configurations for entity relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration for BoardLabel
            modelBuilder.Entity<BoardLabel>()
                .HasOne(b1 => b1.Board)
                .WithMany(t => t.BoardLabels)
                .HasForeignKey(b1 => b1.BoardId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BoardLabel>()
                .HasOne(b1 => b1.Label)
                .WithMany(e => e.BoardLabels)
                .HasForeignKey(b1 => b1.LabelId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration for BoardUser
            modelBuilder.Entity<BoardUser>()
                .HasOne(bu => bu.User)
                .WithMany(u => u.BoardUsers)
                .HasForeignKey(bu => bu.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BoardUser>()
                .HasOne(bu => bu.Board)
                .WithMany(t => t.BoardUsers)
                .HasForeignKey(bu => bu.BoardId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration For Column
            modelBuilder.Entity<Column>()
                .HasOne(c => c.Board)
                .WithMany(t => t.Columns)
                .HasForeignKey(c => c.BoardId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration for Note
            modelBuilder.Entity<Note>()
                .HasOne(n => n.CreatedBy)
                .WithMany(u => u.CreatedNotes)
                .HasForeignKey(n => n.CreatedById)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.Column)
                .WithMany(c => c.Notes)
                .HasForeignKey(n => n.ColumnId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration for NoteLabel
            modelBuilder.Entity<NoteLabel>()
                .HasOne(nl => nl.Note)
                .WithMany(n => n.NoteLabels)
                .HasForeignKey(nl => nl.NoteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NoteLabel>()
                .HasOne(nl => nl.Label)
                .WithMany(l => l.NoteLabels)
                .HasForeignKey(nl => nl.LabelId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration for UserNote
            modelBuilder.Entity<UserNote>()
                .HasOne(un => un.User)
                .WithMany(u => u.UserNotes)
                .HasForeignKey(un => un.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserNote>()
                .HasOne(un => un.Note)
                .WithMany(n => n.UserNotes)
                .HasForeignKey(un => un.NoteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
