using DevStudyNotes.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevStudyNotes.API.Persistence
{
    public class StudyNoteDbContext : DbContext
    {
        public StudyNoteDbContext(DbContextOptions<StudyNoteDbContext> options) : base(options) {

        }

        public DbSet<StudyNote> StudyNotes { get; set; }
        public DbSet<StudyNoteReaction> StudyNotesReactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<StudyNote>(e => {
                e.HasKey(s => s.Id);

                e.HasMany(s => s.Reactions)
                    .WithOne()
                    .HasForeignKey(r => r.StudyNoteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<StudyNoteReaction>(sn => {
                sn.HasKey(s => s.Id);
            });
        }
    }
}