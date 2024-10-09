namespace DevStudyNotes.API.Models
{
    public class AddStudyNoteInputModel
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsPublic { get; set; }
    }
}