using AutoMapper;
using backend.Core.Context;
using backend.Core.Entities;
using backend.Dtos.Job;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{

    

    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private ApplicationDbContext _context { get; }

        private IMapper _mapper { get; }

        public JobController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //Crud
        //Create
        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> CreateJob([FromBody] JobCreateDto dto)
        {
            var newJob = _mapper.Map<Job>(dto);

            await _context.Jobs.AddAsync(newJob);

            await _context.SaveChangesAsync();

            return Ok("Job is created");
        }

        //read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<JobGetDto>>> GetJobs ()
        {
            var jobs = _context.Jobs.Include(job => job.Company).ToListAsync();
            var convertedJobs = _mapper.Map<IEnumerable<JobGetDto>>(jobs);

            return Ok(convertedJobs);
        }
    }
}
