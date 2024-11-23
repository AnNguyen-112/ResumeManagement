using backend.Core.Enums;

namespace backend.Dtos.Company
{
    public class CompanyCreateDtos
    {

        public string Name { get; set; }

        public CompanySize Size { get; set; }
    }
}
