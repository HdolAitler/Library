namespace library.Models;

public class Note
{
    public long NoteId { get; set; }
    public string Title { get; set; } = "";
    public string? Body { get; set; } // Nullable because body can be NULL in schema.sql
    public DateTime CreatedOn { get; set; }
}