using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebApiProj.Models
{
    public class NoteView
    {
        public int Id { get; set; }
        public string NoteText { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
