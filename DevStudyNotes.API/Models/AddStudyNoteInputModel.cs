namespace DevStudyNotes.API.Models
{
    public class AddStudyNoteInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
    }
}