using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineAlbum.Data;
using OnlineAlbum.Models;

namespace OnlineAlbum.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly ApplicationDbContext _context;

        public ImagesController(IHostingEnvironment environment,
                                ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int albumId, List<IFormFile> files)
        {
            //List<Image> images = new List<Image>();
            

            foreach (var item in files)
            {
                if (item.Length > 0)
                {                    
                    Image image = new Image();
                    image.Name = item.FileName; //ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"')
                    image.Extension = Path.GetExtension(item.FileName).ToLower();
                    image.UploadDate = DateTime.Today;
                    image.Location = GetPath(image.Name);
                    image.AlbumId = albumId;
                    var fileStream = new FileStream(image.Location, FileMode.Create);

                    _context.Images.Add(image);
                    await _context.SaveChangesAsync();
                }
                
            }


            return RedirectToAction(nameof(Index));
        }

        private string GetPath(string name)
        {
            string path = _environment.WebRootPath + "\\Upload\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + name;
        }
    }
}