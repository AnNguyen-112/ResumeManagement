﻿using backend.Core.Entities;
using backend.Core.Enums;

namespace backend.Dtos.Job
{
    public class JobGetDto
    {
        public long ID { get; set; }
       

        public string Title { get; set; }
        public JobLevel Level { get; set; }

        public long CompanyId { get; set; }

        public string CompanyName { get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;




    }
}
