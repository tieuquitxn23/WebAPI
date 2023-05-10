using System;

namespace MyWebApiApp.Models
{
    public class HangHoaVM
    {
        public string TenHangHoa { set; get; }

        public string DonGia { set; get; }
    }

    public class HangHoa : HangHoaVM
    {
        public Guid MaHangHoa { set; get; }
    }
}