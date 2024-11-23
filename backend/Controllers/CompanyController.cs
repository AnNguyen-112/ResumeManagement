using AutoMapper;
using backend.Core.Context;
using backend.Core.Entities;
using backend.Dtos.Company;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ApplicationDbContext _context { get; }

        public IMapper _mapper { get; set; }

        public CompanyController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD

        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyCreateDtos dto)
        {
            var newCompany = _mapper.Map<Company>(dto);

            await _context.Companies.AddAsync(newCompany);

            // Save changes to the database
            await _context.SaveChangesAsync();

            return Ok("Company Created Successfully");
        }

        //Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CompanyGetDto>>> GetCompanies()
        {
            var companies = await _context.Companies.ToListAsync();

            var convertedCompanies = _mapper.Map<IEnumerable<CompanyGetDto>>(companies);

            return Ok(convertedCompanies);


        }

        //Read (one company by id)

        //[HttpGet]
        //[Route("Get/:id")]
        //public async Task<ActionResult<CompanyGetDto>> GetCompanyById(int id)
        //{

        //}
        //Update

        //Delete

    }
}
