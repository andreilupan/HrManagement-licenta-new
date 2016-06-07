using System.Web.Mvc;
using HRManagement.Application;
using HRManagement.DataAccess.Models.Models;
using HRManagement.DataAccess;
using System.Net;

namespace HRManagement.Controllers
{
    public class NotesController : Controller
    {
        private INotesService _notesService;
        public HrContext db = new HrContext();

        public NotesController(Application.INotesService notesService)
        {
            _notesService = notesService;
        }
        // GET: Notes
        public ActionResult Index()
        {
            var notes = _notesService.GetNotesForUser(User.Identity.Name);

            var model = new ViewModels.Notes.NotesIndexViewModel
            {
                Notes = notes
            };

            return View(model);
        }

        public ActionResult SetStatus(int id, bool active)
        {
            _notesService.SetNoteStatus(id, active);
            return RedirectToAction("Index");
        }

        public ActionResult Create(ViewModels.Notes.NotesListItemViewModel note)
        {
            _notesService.CreateNote(note.Text, User.Identity.Name);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Note note = db.Notes.Find(id);
            db.Notes.Remove(note);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("api/notes/notifications")]
        public ActionResult GetNotifications()
        {
            var notes = _notesService.GetActiveNotesForUser(User.Identity.Name);

            return Json(notes, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("api/notes/setStatus")]
        public ActionResult GetNotifications(int id, bool status)
        {
            _notesService.SetNoteStatus(id,status);

            return Json("ok", JsonRequestBehavior.AllowGet);
        }

    }
}
