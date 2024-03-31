using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;
using PetitionManagementSystem.Dummy;
using PetitionManagementSystem.Connection;
using PetitionManagementSystem.Models;

namespace PetitionManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatePetitionHandlerForPetitionController : ControllerBase
    {
        private readonly PetitionManagementDBContext _context;
        public UpdatePetitionHandlerForPetitionController(PetitionManagementDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult UpdatePentitionHandlerForPetition([FromBody] UpdatePetitionPetitionHandler updatePetitionPetition)
        {
            var petitionhandler=_context.PetitionHandlers.Find(updatePetitionPetition.PetitionHandlerId);
            var petition = _context.Petition.Find(updatePetitionPetition.PetitionId);
            PentitionPetitionHandler pentitionPetitionHandler = new PentitionPetitionHandler()
            {
                PentitionPetitionHandlerId=0,
                Petition=petition,
                PetitionHandler=petitionhandler
            };
            _context.pentitionPetitionHandlers.Add(pentitionPetitionHandler);
            _context.SaveChanges();
            return Ok();
        }
    }
}
