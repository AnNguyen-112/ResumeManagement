using backend.Core.Entities;
using backend.Core.Enums;

namespace backend.Dtos.Job
{
    public class JobCreateDto
    {

        public string Title { get; set; }
        public JobLevel Level { get; set; }

        //Relations


        public long CompanyId { get; set; }




    }
}
