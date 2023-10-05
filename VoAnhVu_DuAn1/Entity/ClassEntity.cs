using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Entity
{
    [Table("Class")]
    public class ClassEntity
    {
        [Key]
        public string ClassId { get; set; }
        public string ClassName { get; set; }
    }
}
