using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string NoteText { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
