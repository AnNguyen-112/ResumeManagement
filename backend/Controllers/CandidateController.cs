using AutoMapper;
using backend.Core.Context;
using backend.Core.Entities;
using backend.Dtos.Candidate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private ApplicationDbContext _context { get; }

        private Mapper _mapper { get; }

        public CandidateController(ApplicationDbContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Crud
        //create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCandidate([FromForm] CandidateCreateDto dto, IFormFile pdfFile)
        {

            //first => save pdf to Server
            //then => save url into our entity
            var fiveMegaByte = 5 * 1024 * 1024;
            var pdfMimeType = "application/json";

            if (pdfFile.Length > fiveMegaByte || pdfFile.ContentType != pdfMimeType)
            {
                return BadRequest("File is not valid");
            }

            var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", resumeUrl);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }

            var newCandidate = _mapper.Map<Candidate>(dto);
            newCandidate.ResumeUrl = resumeUrl;
            await _context.Candidates.AddAsync(newCandidate);
            await _context.SaveChangesAsync();






            return Ok("Candidate create successfully");
        }


        //get all
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CandidateGetDto>>> GetCandidates()
        {
            var candidates = await _context.Candidates.Include(c => c.Job).ToListAsync();

            var convertedCandidates = _mapper.Map<IEnumerable<Candidate>>(candidates);

            return Ok(convertedCandidates);
        }

        //Reader (Dowload Pdf File)
        [HttpGet]
        [Route("dowload/{url}")]
        public IActionResult DowloadPdfFile(string url)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "document", "pdfs", url);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File Not Existed");
            }

            var pdfBytes = System.IO.File.ReadAllBytes(filePath);
            var file = File(pdfBytes,"application/pdf", url);

            return file;

        }




        //update

    }
}
