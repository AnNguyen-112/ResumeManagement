using backend.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Core.Entities
{
    public class Job: BaseEntity
    {
        public string Title {  get; set; }
        public JobLevel MyProperty { get; set; }

        //Relations

        
        public long CompanyId { get; set; }

        public Company Company { get; set;}

        public ICollection<Candidate> Candidates { get; set; }
    }
}
