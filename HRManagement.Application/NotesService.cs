using System.Collections.Generic;
using HRManagement.DataAccess.Repositories;
using HRManagement.ViewModels.Notes;
using System.Linq;
using System;

namespace HRManagement.Application
{
    public class NotesService : INotesService
    {
        private INotesRepository _notesRepository;

        public NotesService(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public void CreateNote(string text, string name)
        {
            _notesRepository.CreateNote(text, name);
        }

        public List<NotesListItemViewModel> GetActiveNotesForUser(string name)
        {
            return _notesRepository.GetActiveNotesForUser(name).Select(x => new NotesListItemViewModel
            {
                Active = x.Active,
                Id = x.Id,
                Text = x.Text
            }).ToList();
        }

        public List<NotesListItemViewModel> GetNotesForUser(string username)
        {
            return _notesRepository.GetAllNotes(username).Select(x => new NotesListItemViewModel
            {
                Active = x.Active,
                Id = x.Id,
                Text = x.Text
            }).ToList();
        }

        public void SetNoteStatus(int id, bool active)
        {
            _notesRepository.SetNoteStatus(id, active);
        }
    }
}
