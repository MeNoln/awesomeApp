using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Create(T model);
        Task<IEnumerable<T>> GetAllNotes();
        Task<IEnumerable<T>> GetLastUploadedNotes(DateTime time);
    }
}
