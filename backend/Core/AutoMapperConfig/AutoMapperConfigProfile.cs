using AutoMapper;
using backend.Core.Entities;
using backend.Dtos.Candidate;
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
            CreateMap<CandidateCreateDto,Candidate>();
            CreateMap<Candidate, CandidateGetDto>()
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src=> src.Job.Title));
        }
    }
}
