namespace DevStudyNotes.API.Entities
{
    public class StudyNote
    {
        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public bool IsPublic { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public List<StudyNoteReaction> Reactions { get; private set; }

        public StudyNote(string title, string description, bool isPublic)
        {
            Title = title;
            Description = description;
            IsPublic = isPublic;

            CreatedAt = DateTime.Now;
            Reactions = new List<StudyNoteReaction>();
        }

        public void AddReaction(bool isPositive)
        {
            if (!IsPublic)
                throw new InvalidOperationException();

            Reactions.Add(new StudyNoteReaction(isPositive));
        }
    }
}