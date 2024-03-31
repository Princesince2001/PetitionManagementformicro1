using Microsoft.AspNetCore.Mvc;
using PetitionManagementSystem.Connection;
using PetitionManagementSystem.Models;

namespace PetitionManagementSystem.Controllers
{
    public class CategoryController:ControllerBase
    {

        private readonly PetitionManagementDBContext context;


        public CategoryController(PetitionManagementDBContext context)
        {
            this.context = context;
        }

        //[HttpPost]
        //public IActionResult Post([FromBody] Clatoocs clatoocs)
        //{
        //    if (clatoocs == null)
        //    {
        //        return BadRequest();
        //    }


        //    return CreatedAtAction(nameof(Post), new { id = clatoocs.CategoryId }, clatoocs);
        //}


        [Route("/api/Categorydetails")]
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {

            return context.Category.ToList();
        }

  
    }
}
