using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;

namespace PetitionManagementSystem.Models
{
    public class Pethan
    {

        public int PetitionHandlerId { get; set; }

        public int OfficialId { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public int CategoryId { get; set; }

        public string? MobileNumber { get; set; }

        public string Password { get; set; }     //changed

        public string? TalukLocation { get; set; }
        public int AdminId { get; set; }

      

       // public string CategoryName { get; set; }

        //public string StatusType { get; set; }


    }
}
