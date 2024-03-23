
using PetitionManagementSystem.Connection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetitionManagementSystem.Models;

using System;
using System.Linq.Expressions;
using PetitionManagementSystem.Dummy;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;


namespace PetitionManagementSystem.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PetitionhandlerController : ControllerBase
    {

        private readonly PetitionManagementDBContext context;
        public PetitionhandlerController(PetitionManagementDBContext context)
        {
            this.context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Pethan petition)
        {

            Category category = context.Category.Find(petition.CategoryId);

            Admin admin = context.Admin.Find(petition.AdminId);

            PetitionHandler petition1 = new PetitionHandler()
            {

                PetitionHandlerId = petition.PetitionHandlerId, // model name
                OfficialId = petition.OfficialId,
                UserName = petition.UserName,
                Email = petition.TalukLocation,
                MobileNumber = petition.MobileNumber,
                TalukLocation = petition.TalukLocation,
                Status = 1,
                Category = category,
                Admin = admin,


            };

            context.PetitionHandlers.Add(petition1); //table
            await context.SaveChangesAsync();
            return Ok();
        }
        //fetch
        [Route("/api/FetchPetitionhandlersdetails")]
        [HttpGet]
        public async Task<IEnumerable<PetitionHandler>> Get()
        {
            return context.PetitionHandlers.ToList();
        }

        [Route("api/FetchPetitionhandlersdetails/{id}")]
        [HttpGet]
        public ActionResult<PetitionHandler> GetIndividual(int id)
        {
            var product = context.PetitionHandlers.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [Route("api/UpdatePetitionHandler")]
        [HttpPut]

        public async Task<IActionResult> Put([FromForm] Pethan petition)
        {

            Category category = context.Category.Find(petition.CategoryId);

            Admin admin = context.Admin.Find(petition.AdminId);

            PetitionHandler petition1 = new PetitionHandler()
            {

                PetitionHandlerId = petition.PetitionHandlerId, // model name
                OfficialId = petition.OfficialId,
                UserName = petition.UserName,
                Email = petition.TalukLocation,
                MobileNumber = petition.MobileNumber,
                TalukLocation = petition.TalukLocation,
                Status = 1,
                Category = category,
                Admin = admin,


            };

            context.PetitionHandlers.Update(petition1); //table
            await context.SaveChangesAsync();
            return Ok();
        }

        [Route("api/DeleteProduct/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await context.PetitionHandlers.FindAsync(id);

            product.Status = 0;
            context.PetitionHandlers.Update(product); //table
            await context.SaveChangesAsync();
            return Ok();

        }
            
    }
}


