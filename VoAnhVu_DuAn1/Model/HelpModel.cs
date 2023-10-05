using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;

namespace VoAnhVu_DuAn1.Model
{
    public class HelpModel
    {
        public string HelpId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public UserEntity User { get; set; }
    }
}
