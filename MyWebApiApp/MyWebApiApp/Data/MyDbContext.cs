using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        #region Dbset
        public DbSet<HangHoa> HangHoas { set; get; }
        public DbSet<Loai> Loais { set; get; }
        #endregion

    }
}
