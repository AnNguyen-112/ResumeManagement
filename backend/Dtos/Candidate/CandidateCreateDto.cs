﻿namespace backend.Dtos.Candidate
{
    public class CandidateCreateDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeUrl { get; set; }

        //Relations
        public long JobId { get; set; }
        
    }
}
