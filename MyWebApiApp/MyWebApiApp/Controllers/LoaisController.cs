using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoaisController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefaultAsync(lo => lo.MaLoai == id);
            if (loai != null)
            {
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id, LoaiModel model)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}