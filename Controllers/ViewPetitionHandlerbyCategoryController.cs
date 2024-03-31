using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetitionManagementSystem.Connection;
using Microsoft.EntityFrameworkCore;
namespace PetitionManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewPetitionHandlerbyCategoryController : ControllerBase
    {
        private readonly PetitionManagementDBContext dbContext;
        public ViewPetitionHandlerbyCategoryController(PetitionManagementDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [Route("/GetById/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var category = dbContext.Category.Find(id);
            var petitionhandlerbycategory= dbContext.PetitionHandlers.Include(a=>a.Category).Where(x => x.Category == category).ToList();
            return Ok(petitionhandlerbycategory);
           
        }
    }
}
