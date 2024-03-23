using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PetitionManagementSystem.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }


        [Required]
       public string? AdminName { get; set; }

        [Required]
        public string? Adminmobilenumber { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

        public ICollection<Category> Category { get; } = new List<Category>();

    public ICollection<PetitionHandler> PetitionHandler { get;  } = new List<PetitionHandler>();

    }
}
