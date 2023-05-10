using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApp.Data
{
    public class HangHoa
    {
        [Key]
        public Guid MaHh { set; get; }
        [Required]
        [MaxLength(100)]
        public string TenHh { set; get; }
        public string MoTa { set; get; }
        [Range(0, double.MaxValue)]
        public double DonGia { set; get; }
        public byte GiamGia { set; get; }
        public int? MaLoai { set; get; }
        [ForeignKey("MaLoai")]
        public Loai Loai { set; get; }
    }
}
