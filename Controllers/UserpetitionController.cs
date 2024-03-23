using PetitionManagementSystem.Connection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetitionManagementSystem.Models;

using System;
using System.Linq.Expressions;
using PetitionManagementSystem.Dummy;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PetitionManagementSystem.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserpetitionController:ControllerBase
    {
        private readonly PetitionManagementDBContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;
        public UserpetitionController(PetitionManagementDBContext context, IWebHostEnvironment environment, IConfiguration configuration)
        {
            _context = context;
            _environment = environment;
            _configuration = configuration;
        }
        [Route("/Add/[action]")]


        [HttpPost]
        public async Task<IActionResult> Post([FromForm] PetForm1 petition)
        {

            var uniqueFileName = $"{Guid.NewGuid()}_{petition.UploadDocument.FileName}";

            // Save the image to a designated folder (e.g., wwwroot/images)


            var uploadsFolder = Path.Combine(_environment.WebRootPath, "Images");
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await petition.UploadDocument.CopyToAsync(stream);
            }

            // Store the file path in the database
            petition.UploadDocumentname= uniqueFileName;
            

            Category category = _context.Category.Find(petition.CategoryId);

            User user=_context.User.Find(petition.UserId);



            Petition petition1 = new Petition()
            {

                PetitionDescription = petition.PetitionDescription,
                UploadDocumentname=petition.UploadDocumentname, 
                AadharNumber = petition.AadharNumber,
                TalukLocation = petition.TalukLocation,
                Address = petition.Address,
                Category = category,
                User = user

            };

            _context.Petition.Add(petition1);
            await _context.SaveChangesAsync();
            return Ok(User);

        }

        [HttpGet]
        public IActionResult GetAllPetAccessoryy()
        {
            var pete = _context.Petition.ToList();

            var petitionList = new List<object>();

            foreach (var pet in pete)
            {

                // Create an object containing cart details and image URL
                var petData = new
                {
                    id = pet.PetitionId,
                    PetitionDescription = pet.PetitionDescription,
                    AadharNumber = pet.AadharNumber,
                    TalukLocation = pet.TalukLocation,
                    Address = pet.Address,
                    UploadDocument=pet.UploadDocument,
                    //UploadDocumentname= pet.UploadDocumentname,
                   
                   imageUrl = String.Format("{0}://{1}{2}/wwwroot/images/{3}", Request.Scheme, Request.Host, Request.PathBase, pet.UploadDocumentname)
                };

                petitionList.Add(petData);
            }

            return Ok(petitionList);
        }
        [HttpGet("{id}/Image")]
        public IActionResult GetPeteImage(int id)
        {
            var petaccessory = _context.Petition.Find(id);
            if (petaccessory == null)
            {
                return NotFound(); // User not found
            }

            // Construct the full path to the image file

            var imagePath = Path.Combine(_environment.WebRootPath, "Images", petaccessory.UploadDocumentname);

            // Check if the image file exists
            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound(); // Image file not found
            }

            // Serve the image file
            return PhysicalFile(imagePath, "Image/jpeg");
        }

        [Route("api/DeletePetition/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePetition(int id)
        {
            if (id < 1)
                return BadRequest();
            var product = await _context.Petition.FindAsync(id);
            if (product == null)
                return NotFound();
            _context.Petition.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Route("api/UpdatePetetionform")]
        [HttpPut]
        public async Task<IActionResult> Updateuser(Petition Product)
        {
            if (Product == null || Product.PetitionId == 0)
                return BadRequest();


            _context.Entry(Product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
