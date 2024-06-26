﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetitionManagementSystem.Models
{
    public class Petition
    {
        [Key]
        public int PetitionId { get; set; }
      public string? PetitionDescription { get; set; }

        [NotMapped]
        public IFormFile? UploadDocument { get; set; }

        public string ?UploadDocumentname { get; set; }

        public long AadharNumber { get; set; }
        public string? TalukLocation { get; set; }
          public string? Address { get; set; }
        public string? StatusType { get; set; }
        public string Date {  get; set; }   
        //public ICollection<PentitionPetitionHandler> Handler { get; set; }
        //public PetitionHandler petitionHandler { get; set; }

        public Category Category { get; set; }

        public User User { get; set; }
    }
}
