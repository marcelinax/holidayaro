using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Holidayaro.Data;
using Holidayaro.Models;
using Microsoft.AspNetCore.Authorization;
using System.Dynamic;
using Holidayaro.Repositories;

namespace Holidayaro.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelsRepository _hotelRepository;

        public HotelsController(IHotelsRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [Authorize]
        public async Task<IActionResult> Index(int pageSize, int startIndex = -1)
        {
            ViewBag.Results = _hotelRepository.GetManyByPageSizeAndOffset(pageSize, startIndex);
            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            } 
            var hotel = _hotelRepository.FindOneById((int)id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create([Bind("HotelId,Name,Country,Price,PhotoUrl,Rating,Days,Room,Board")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _hotelRepository.AddNew(hotel);
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = _hotelRepository.FindOneById((int)id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Edit(int id, [Bind("HotelId,Name,Country,Price,PhotoUrl,Rating,Days,Room,Board")] Hotel hotel)
        {
            if (id != hotel.HotelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _hotelRepository.UpdateOne(hotel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.HotelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = _hotelRepository.FindOneById((int)id);

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _hotelRepository.DeleteOneById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
            return _hotelRepository.CheckIfExistsById(id);
        }
    }
}
