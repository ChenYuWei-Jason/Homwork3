using AJAX.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AJAX.Controllers
{

    public class ApiController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        private readonly DemoContext _context;

        public ApiController(DemoContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult consider(Member member, IFormFile file)
        {
            //string info = $"{file.FileName}-{file.Length}-{file.ContentType}";

            string uploadsfolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads");
            string filePath = Path.Combine(uploadsfolder, file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            byte[] imgByte = null;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }
            member.FileName = file.FileName;
            member.FileData = imgByte;

            _context.Members.Add(member);
            _context.SaveChanges();

            return Content($"檔案名稱{file.FileName}", "text/plan", System.Text.Encoding.UTF8);
        }
        public IActionResult Index(user user)
        {
            //System.Threading.Thread.Sleep(5000);
            //return Content("Hello", "text/html", System.Text.Encoding.UTF8);
            if (string.IsNullOrEmpty(user.name))
            {
                user.name = "Jack";
            }
            return Content($"{user.name}你好，你的年紀是{user.age}");
        }
        public IActionResult GetImageBytes(int id = 1)
        {
            Member member = _context.Members.Find(id);
            byte[] img = member.FileData;
            return File(img, "image/jpeg");
        }

            public IActionResult City()
        {
            var citise = _context.Addresses.Select(a => a.City).Distinct();
            return Json(citise);
        }
        public IActionResult Districts(string city)
        {
            var districts = _context.Addresses.Where(a => a.City == city).Select(b => b.SiteId).Distinct();
            return Json(districts);
        }
        public IActionResult Roads(string districts)
        {
            var roads = _context.Addresses.Where(a => a.SiteId == districts).Select(b => b.Road);
            return Json(roads);
        }
    }
}
