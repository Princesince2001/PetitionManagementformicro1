using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace PetitionManagementSystem.Models
{
    public class PetForm1
    {
        public int PetitionId { get; set; }

        public string? PetitionDescription { get; set; }
        [NotMapped]
        public IFormFile ?UploadDocument { get; set; }
        public string? UploadDocumentname { get; set; }

        public long AadharNumber { get; set; }

        public string? TalukLocation { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }                                                   

        public int CategoryId { get; set; }

        public int UserId { get; set; }

    }
}


