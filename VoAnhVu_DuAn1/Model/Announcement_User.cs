using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Model
{
    public class Announcement_User
    {
        [Key]
        public int AnnUserId { get; set; }
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("AnnouncementId")]
        public int? AnnouncementId { get; set; }
        public Announcement Announcement { get; set; }
    }
}
