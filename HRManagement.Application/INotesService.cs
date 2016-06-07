using System.Collections.Generic;


namespace HRManagement.Application
{
    public interface INotesService
    {
        List<ViewModels.Notes.NotesListItemViewModel> GetNotesForUser(string username);
        void SetNoteStatus(int id, bool active);
        void CreateNote(string text,  string name);
        List<ViewModels.Notes.NotesListItemViewModel> GetActiveNotesForUser(string name);
    }
}
