using Microsoft.EntityFrameworkCore;
using PetitionManagementSystem.Controllers;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PetitionManagementSystem.Models
{
    public class PetitionHandler
    {
        public int PetitionHandlerId { get; set; }

        public int OfficialId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? MobileNumber { get; set; }

        public string? TalukLocation { get; set; }

        public int Status { get; set; }
  
        public Category Category { get; set; }

        public Admin Admin { get; set; }
        //public ICollection<PentitionPetitionHandler> Handler { get; set; }

        // public ICollection<Petition> Petitions { get; }


    }
}
