using AutoMapper;
using backend.Core.Entities;
using backend.Dtos.Company;
using backend.Dtos.Job;

namespace backend.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile: Profile
    {

        public AutoMapperConfigProfile()
        {

            //company
            CreateMap<CompanyCreateDtos, Company>();

            CreateMap<Company, CompanyGetDto>();


            //job
            CreateMap<JobCreateDto, Job>();

            CreateMap<Job, JobGetDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));

            //candidate
        }
    }
}
