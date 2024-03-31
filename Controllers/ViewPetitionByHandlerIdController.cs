using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetitionManagementSystem.Connection;

namespace PetitionManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewPetitionByHandlerIdController : ControllerBase
    {
        private readonly PetitionManagementDBContext _context;
        public ViewPetitionByHandlerIdController(PetitionManagementDBContext  context)
        {
            _context = context;
        }
        [Route("/Viewbyid/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var handler = _context.PetitionHandlers.Find(id);
            var petitionlistbyhandler=_context.pentitionPetitionHandlers.Include(x => x.PetitionHandler).Include(u=>u.Petition).Where(x => x.PetitionHandler == handler).ToList();
            
            
            return Ok(petitionlistbyhandler);
            //return Ok(handler);
        }
    }
}
