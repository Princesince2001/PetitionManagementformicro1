using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetitionManagementSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }

        public string? MobileNumber { get; set; }

        public string? Address { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Petition> Petition { get; } = new List<Petition>();


    }
}
