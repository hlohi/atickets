using atickets.Data;
using atickets.Data.Services;
using atickets.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        { 
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // Get request: Actors/Create
        public IActionResult Create()
        {
            return View();
        }


                                             // we use the Bind to bind togerther the different properties            
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);

            }
           await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);


        }

        // Get request: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }


        // we use the Bind to bind togerther the different properties            
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);

            }
            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }


        // Get request: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }


        // we use the Bind to bind togerther the different properties            
        [HttpPost, ActionName("Delete")]
        // To delete an actor from the database we just need an id
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // checking if the actor exists
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
