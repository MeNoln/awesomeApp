using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class Repository : IRepository<Note>
    {
        private PostgreDbContext db;
        public Repository(PostgreDbContext db)
        {
            this.db = db;
        }

        public async Task<Note> Create(Note model)
        {
            db.Notes.Add(model);
            db.SaveChanges();
            return await db.Notes.Where(i => i.Id == model.Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Note>> GetAllNotes() => await db.Notes.ToListAsync();
        
        public async Task<IEnumerable<Note>> GetLastUploadedNotes(DateTime time) => await db.Notes.Where(d => d.AddedDate > time).ToListAsync();
        
    }
}
