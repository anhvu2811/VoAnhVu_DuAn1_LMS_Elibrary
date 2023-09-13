using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Model
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt)
        {

        }
        #region Dbset
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<VoAnhVu_DuAn1.Model.Announcement> Announcement { get; set; }
        #endregion
    }
}
