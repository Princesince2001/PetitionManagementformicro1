using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetitionManagementSystem.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        //public ICollection<Petition> Petition { get; } = new List<Petition>();
    //    public ICollection<PetitionHandler> PetitionHandler { get;  } = new List<PetitionHandler>();

        public Admin Admin { get; set; }  


    }
}
