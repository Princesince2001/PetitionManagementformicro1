using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetitionManagementSystem.Connection;
using PetitionManagementSystem.Models;
using PetitionManagementSystem.Operation;
namespace PetitionManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetitionStatusApprovalController : ControllerBase
    {
        private readonly PetitionManagementDBContext _dbContext;
        public PetitionStatusApprovalController(PetitionManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult Post([FromBody] StatusController statusController)
        {
            var petition = _dbContext.Petition.Include(x=>x.User).Where(x=>x.PetitionId==statusController.petitionId).FirstOrDefault();
            petition.StatusType = statusController.StatusType;

            _dbContext.Petition.Update(petition);
            _dbContext.SaveChanges();
            EmailGenerator.SendEmail(petition.User.Email, petition.StatusType);
            return Ok();

      
        }

         
    }
}
