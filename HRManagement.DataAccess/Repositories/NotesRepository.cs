using System;
using System.Collections.Generic;
using System.Linq;
using HRManagement.DataAccess.Models.Models;
using HRManagement.ViewModels.Notes;

namespace HRManagement.DataAccess.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private HrContext _db;
        public NotesRepository(HrContext db)
        {
            _db = db;
        }
        public IQueryable<Note> GetAllNotes(string username)
        {
            return _db.Notes.Where(x => x.Username == username);
        }

        public void SetNoteStatus(int id, bool active)
        {
            _db.Notes.Find(id).Active = active;
            _db.SaveChanges();
        }

        public void CreateNote(string text, string name)
        {
            _db.Notes.Add(new Note
            {
                Text = text,
                Active = true,
                Username = name
            });

            _db.SaveChanges();
        }

        public List<Note> GetActiveNotesForUser(string username)
        {
            return GetAllNotes(username).Where(x => x.Active == true).ToList();
        }

        IQueryable<Note> INotesRepository.GetActiveNotesForUser(string username)
        {
            return GetAllNotes(username).Where(x => x.Active);
        }
    }
}
