using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetitionManagementSystem.Connection;
using PetitionManagementSystem.Dummy;

namespace PetitionManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly PetitionManagementDBContext _dbContext;
        public DashboardController(PetitionManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var TotalPetition = _dbContext.Petition.ToList().Count();
            var PendingPetition = _dbContext.Petition.Where(x=>x.StatusType.ToUpper()=="PENDING").ToList().Count();
            var ResolvedPetition= _dbContext.Petition.Where(x => x.StatusType.ToUpper() == "RESOLVED").ToList().Count();
            var RejectedPetition= _dbContext.Petition.Where(x => x.StatusType.ToUpper() == "REJECTED").ToList().Count();
            var ClosedPetition = _dbContext.Petition.Where(x => x.StatusType.ToUpper() == "CLOSED").ToList().Count();
            var ActivePetitionHandler= _dbContext.PetitionHandlers.Where(x=>x.Status==1).ToList().Count();
            var RevenuePetitionHandler= _dbContext.PetitionHandlers.Include(a=>a.Category).Where(x=>x.Category.CategoryId==1).ToList().Count();
            var EducationPetitionHandler= _dbContext.PetitionHandlers.Include(a => a.Category).Where(x=>x.Category.CategoryId==2).ToList().Count();
            var TransportPetitionHandler = _dbContext.PetitionHandlers.Include(a => a.Category).Where(x => x.Category.CategoryId == 3).ToList().Count();
            var HealthcarePetitionHandler = _dbContext.PetitionHandlers.Include(a => a.Category).Where(x => x.Category.CategoryId==4).ToList().Count();
         

            Dashboard dashboard = new Dashboard()
            {
                TotalPetition=TotalPetition,
                PendingPetiton=PendingPetition,
                RejectedPetition=RejectedPetition,
                ResolvedPetition=ResolvedPetition,
                ClosedPetition=ClosedPetition,
                ActiveHandler=ActivePetitionHandler,
                RevenueHandler=RevenuePetitionHandler,
                EducationHandler=EducationPetitionHandler,
                TransportHandler=TransportPetitionHandler,
                HealthcareHandler = HealthcarePetitionHandler
            };
            return Ok(dashboard);

        }
    }
}
