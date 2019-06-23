using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BisnessLogic;
using BisnessLogic.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MvcWebApp.Models;
using MvcWebApp.SignalHub;

namespace MvcWebApp.Controllers
{
    public class HomeController : Controller
    {
        private BL db;
        IHubContext<ChatHub> hub;
        public HomeController(BL db, IHubContext<ChatHub> hub)
        {
            this.db = db;
            this.hub = hub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClientOne()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NoteView model)
        {
            DTONote note = new DTONote { AddedDate = model.AddedDate, NoteText = model.NoteText };
            var dtoNote = await db.AddNote(note);

            await hub.Clients.All.SendAsync("Send", dtoNote);

            return RedirectToAction("ClientOne");
        }

        public async Task<IActionResult> ClientTwo()
        {
            List<NoteView> result = new List<NoteView>();
            foreach (var item in await db.GetAll())
                result.Add(new NoteView { Id = item.Id, NoteText = item.NoteText, AddedDate = item.AddedDate });

            return View(result);
        }

        public async Task<IActionResult> ClientThree()
        {
            List<NoteView> result = new List<NoteView>();
            foreach (var item in await db.GetLastNotes())
                result.Add(new NoteView { Id = item.Id, NoteText = item.NoteText, AddedDate = item.AddedDate });

            return View(result);
        }
    }
}