using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Model
{
    [Table("Announcement")]
    public class Announcement
    {
        [Key]
        public int AnnouncementId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public virtual ICollection<Announcement_User> Announcement_Users { get; set; }
    }
}
