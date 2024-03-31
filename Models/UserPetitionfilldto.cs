using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetitionManagementSystem.Models
{
    public class Petitionformdto
    {
        public int PetitionId { get; set; }
        public string? PetitionDescription { get; set; }

        [NotMapped]
        public IFormFile? UploadDocument { get; set; }

        public string? UploadDocumentname { get; set; }

        public long AadharNumber { get; set; }
        public string? TalukLocation { get; set; }
        public string? Address { get; set; }

        public Category Category { get; set; }

        public Category CategoryName { get; set; }


        public User User { get; set; }

        public int UserId { get; set; }
    }
}
