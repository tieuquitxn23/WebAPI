using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia,
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true,
                Data = hanghoa
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                //LINQ [Object] Query
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hangHoaEdit)
        {
            try
            {
                //LINQ [Object] Query
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }

                if(id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                // Update
                hanghoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hanghoa.DonGia = hangHoaEdit.DonGia;
            }
            catch
            {
                return BadRequest();
            }
            return Ok(hangHoaEdit);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                //LINQ [Object] Query
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }

                if (id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                // Remove
                hangHoas.Remove(hanghoa);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}