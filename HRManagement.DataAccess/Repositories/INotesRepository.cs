using System.Collections.Generic;
using HRManagement.ViewModels.Notes;

namespace HRManagement.DataAccess.Repositories
{
    public interface INotesRepository
    {
        System.Linq.IQueryable<Models.Models.Note> GetAllNotes(string username);
        void SetNoteStatus(int id, bool active);
        void CreateNote(string text, string name);
        System.Linq.IQueryable<Models.Models.Note> GetActiveNotesForUser(string username);
    }
}
