using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;

namespace VoAnhVu_DuAn1.Model
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt)
        {

        }
        #region
        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<ClassEntity> ClassEntities { get; set; }
        public DbSet<EnrollmentEntity> EnrollmentEntities { get; set; }
        public DbSet<SubjectEntity> SubjectEntities { get; set; }
        public DbSet<HelpEntity> HelpEntities { get; set; }
        public DbSet<LectureEntity> LectureEntities { get; set; }
        public DbSet<TopicEntity> TopicEntities { get; set; }
        public DbSet<QuestionEntity> QuestionEntities { get; set; }
        public DbSet<AnswerEntity> AnswerEntities { get; set; }
        #endregion

    }
}
