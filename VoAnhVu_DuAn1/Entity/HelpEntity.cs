using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Entity
{
    [Table("Help")]
    public class HelpEntity
    {
        [Key]
        public string HelpId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
