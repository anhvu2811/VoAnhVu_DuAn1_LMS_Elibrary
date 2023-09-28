using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Entity
{
    [Table("Topic")]
    public class TopicEntity
    {
        [Key]
        public string TopicId { get; set; }
        public string TopicName { get; set; }
        public string Description { get; set; }
    }
}
