using System;
using System.Collections.Generic;
using System.Text;

namespace BisnessLogic.Entities
{
    public class DTONote
    {
        public int Id { get; set; }
        public string NoteText { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
