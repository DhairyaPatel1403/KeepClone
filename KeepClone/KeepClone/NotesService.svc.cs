using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KeepClone
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class NotesService : INotesService
    {
        public List<Diary> GetAllDiaries(string username)
        {
            using (var db = new noteskeepEntities())
            {
                // Filter diaries by user_id
                return db.Diaries.Where(d => d.username == username).ToList();
            }
        }


        public List<Note> GetAllNotes()
        {
            using (var db = new noteskeepEntities())
            {
                return db.Notes.ToList();
            }
        }

        public Note GetNote(string id)
        {
            Int32 _id = Convert.ToInt32(id);
            using (var db = new noteskeepEntities())
            {
                return db.Notes.SingleOrDefault(p => p.Id == _id);
            }
        }

        public List<Note> GetNotesByDiaryId(string diaryId)
        {
            using (var db = new noteskeepEntities())
            {
                return db.Notes.Where(n => n.Diaryid == diaryId).ToList();
            }
        }


        public void AddDiary(string name, string username)
        {
            using (var db = new noteskeepEntities())
            {
                Diary _diary = new Diary
                {
                    Diary_name = name,
                    username = username
                };
                db.Diaries.Attach(_diary);
                db.Diaries.Add(_diary);
                db.SaveChanges();
            }
        }

        public void AddNote(string name, string diaryid)
        {
            using (var db = new noteskeepEntities())
            {
                Note _note= new Note
                {
                    Name = name,
                    Diaryid = diaryid,
                    Notecontent = ""
                };
                db.Notes.Attach(_note);
                db.Notes.Add(_note);
                db.SaveChanges();
            }
        }



        public void UpdateNoteContent(string id, string newContent)
        {
            if (!int.TryParse(id, out int noteId))
            {
                throw new ArgumentException("Invalid note ID.");
            }

            using (var db = new noteskeepEntities())
            {
                // Find the note by ID
                var note = db.Notes.FirstOrDefault(n => n.Id == noteId);

                // Update the note content
                note.Notecontent = newContent;

                // Save changes to the database
                db.SaveChanges();
            }
        }

        public void DeleteNote(string noteid)
        {
            // Convert noteid to appropriate data type if necessary (e.g., int)
            int noteId = Convert.ToInt32(noteid);

            // Your code to delete the note using the provided noteId
            // For example:
            using (var db = new noteskeepEntities())
            {
                var noteToDelete = db.Notes.FirstOrDefault(n => n.Id == noteId);
                if (noteToDelete != null)
                {
                    db.Notes.Remove(noteToDelete);
                    db.SaveChanges();
                }
            }
        }

        public void DeleteDiary(string diaryid)
        {
            // Convert noteid to appropriate data type if necessary (e.g., int)
            int diaryId = Convert.ToInt32(diaryid);
            string diaryIdString = diaryId.ToString();

            // Your code to delete the note using the provided noteId
            // For example:
            using (var db = new noteskeepEntities())
            {
                var diaryToDelete = db.Diaries.FirstOrDefault(n => n.Id == diaryId);
                if (diaryToDelete != null)
                {
                    // Delete associated notes first
                    var notesToDelete = db.Notes.Where(n => n.Diaryid == diaryIdString);
                    db.Notes.RemoveRange(notesToDelete);


                    db.Diaries.Remove(diaryToDelete);
                    db.SaveChanges();
                }

                //Delete here all the associated notes wiht Diaryid==diaryIdString
            }
        }


        public void AddUser(string username, string password)
        {
            using (var db = new noteskeepEntities())
            {
                User _user = new User 
                { 
                    Username = username,
                    Password = password
                };
                db.Users.Attach(_user);
                db.Users.Add(_user);
                db.SaveChanges();
            }
        }


        public List<User> GetAllUsers()
        {
            using (var db = new noteskeepEntities())
            {
                return db.Users.ToList();
            }
        }

        public List<Note> GetNoteById(string noteid)
        {
            Int32 _id = Convert.ToInt32(noteid);
            using (var db = new noteskeepEntities())
            {

                return db.Notes.Where(n => n.Id == _id).ToList();
            }
        }

    }
}
