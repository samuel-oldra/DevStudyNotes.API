namespace DevStudyNotes.API.Entities
{
    public class StudyNoteReaction
    {
        public int Id { get; private set; }

        public bool IsPositive { get; private set; }

        public int StudyNoteId { get; private set; }

        public StudyNoteReaction(bool isPositive)
            => IsPositive = isPositive;
    }
}