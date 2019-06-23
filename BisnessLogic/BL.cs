using AutoMapper;
using BisnessLogic.Entities;
using DataAccessLayer;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BisnessLogic
{
    public class BL
    {
        private UnitOfWork db { get; }
        public BL()
        {
            db = new UnitOfWork();
        }

        public async Task<DTONote> AddNote(DTONote model)
        {
            model.AddedDate = DateTime.Now;
            Note noteModel = new Note {  AddedDate = model.AddedDate, NoteText = model.NoteText };

            Note note = await db.Notes.Create(noteModel);
            return new DTONote { Id = note.Id, NoteText = note.NoteText, AddedDate = note.AddedDate };
        }

        public async Task<IEnumerable<DTONote>> GetAll()
        {
            List<DTONote> result = new List<DTONote>();
            foreach (var item in await db.Notes.GetAllNotes())
                result.Add(new DTONote { Id = item.Id, NoteText = item.NoteText, AddedDate = item.AddedDate });

            return result;
        }

        public async Task<IEnumerable<DTONote>> GetLastNotes()
        {
            var lastTenMin = DateTime.Now.Subtract(TimeSpan.FromMinutes(10));
            List<DTONote> result = new List<DTONote>();
            foreach (var item in await db.Notes.GetLastUploadedNotes(lastTenMin))
                result.Add(new DTONote { Id = item.Id, NoteText = item.NoteText, AddedDate = item.AddedDate });

            return result;
        }
    }
}
