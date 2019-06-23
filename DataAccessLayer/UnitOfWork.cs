using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private PostgreDbContext db { get; }
        private Repository noteRepository;
        public UnitOfWork()
        {
            db = new PostgreDbContext();
        }

        public IRepository<Note> Notes
        {
            get
            {
                if (noteRepository == null)
                    noteRepository = new Repository(db);
                return noteRepository;
            }
        }
    }
}
