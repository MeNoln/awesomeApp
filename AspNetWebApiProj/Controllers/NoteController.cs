using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetWebApiProj.Models;
using AutoMapper;
using BisnessLogic;
using BisnessLogic.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetWebApiProj.Controllers
{
    [Route("api/note")]
    [ApiController]
    public class NoteController : Controller
    {
        private BL db;
        public NoteController(BL db)
        {
            this.db = db;
        }

        [HttpGet]
        public string Res()
        {
            return "ww";
        }

        [HttpGet,Route("g")]
        public async Task<IActionResult> GetAll()
        {
            List<NoteView> result = new List<NoteView>();
            foreach (var item in await db.GetAll())
                result.Add(new NoteView { Id = item.Id, NoteText = item.NoteText, AddedDate = item.AddedDate });

            return Json(result);
        }

        [HttpGet, Route("last")]
        public async Task<IActionResult> GetLast()
        {
            List<NoteView> result = new List<NoteView>();
            foreach (var item in await db.GetLastNotes())
                result.Add(new NoteView { Id = item.Id, NoteText = item.NoteText, AddedDate = item.AddedDate });

            return Json(result);
        }

        [HttpPost]
        public IActionResult Create(NoteView model)
        {
            DTONote note = new DTONote { AddedDate = model.AddedDate, NoteText = model.NoteText };
            db.AddNote(note);

            return Ok("added");
        }
    }
}