﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;

namespace VoAnhVu_DuAn1.Model
{
    public class SubjectModel
    {
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public TopicEntity Topic { get; set; }
    }
}
