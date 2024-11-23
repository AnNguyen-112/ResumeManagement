using backend.Core.Enums;

namespace backend.Dtos.Company
{
    public class CompanyGetDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public CompanySize Size { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

       
    }
}
