using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Holidayaro.Data;
using Holidayaro.Models;
using Microsoft.AspNetCore.Authorization;
using Holidayaro.Repositories;

namespace Holidayaro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosUrlsController : ControllerBase
    {
        private readonly IRepository<PhotosUrl> _photosUrlsRepository;

        public PhotosUrlsController(IRepository<PhotosUrl> photosUrlsRepository)
        {
            _photosUrlsRepository = photosUrlsRepository;
        }

        [HttpGet]
        public IEnumerable<PhotosUrl> GetPhotosUrl()
        {
            return _photosUrlsRepository.FindAll();
        }

        [HttpGet("{id}")]
        public ActionResult<PhotosUrl> GetPhotosUrl(int id)
        {
            var photosUrl = _photosUrlsRepository.FindOneById(id);

            if (photosUrl == null)
            {
                return NotFound();
            }

            return photosUrl;
        }

        [HttpPut("{id}")]
        [Authorize]
        public PhotosUrl PutPhotosUrl(int id, PhotosUrl photosUrl)
        {
            return _photosUrlsRepository.UpdateOne(photosUrl);
        }

        [HttpPost]
        [Authorize]
        public  ActionResult<PhotosUrl> PostPhotosUrl(PhotosUrl photosUrl)
        {
            _photosUrlsRepository.AddNew(photosUrl);

            return CreatedAtAction("GetPhotosUrl", new { id = photosUrl.PhotosUrlId }, photosUrl);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeletePhotosUrl(int id)
        {
             _photosUrlsRepository.DeleteOneById(id);
            return NoContent();
        }

        private bool PhotosUrlExists(int id)
        {
            return _photosUrlsRepository.CheckIfExistsById(id);
        }
    }
}
