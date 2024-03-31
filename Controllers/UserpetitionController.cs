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
using System.Data.Entity;
using Microsoft.IdentityModel.Tokens;

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

            //Category category1= _context.Category.Find(petition.CategoryName);





            Petition petition1 = new Petition()
            {

                PetitionDescription = petition.PetitionDescription,
                UploadDocumentname = petition.UploadDocumentname,
                AadharNumber = petition.AadharNumber,
                TalukLocation = petition.TalukLocation,
                Address = petition.Address,

                Date = DateTime.UtcNow.Date.ToString(),
                Category = category,
                User = user,
                StatusType = "Pending"

            };

            Random rnd= new Random();
            petition1.PetitionId = rnd.Next(1111, 9999);
            if (_context.Petition.Any(x=>x.PetitionId==petition1.PetitionId))
            {
                petition1.PetitionId = rnd.Next(1111, 9999);

            }
            _context.Petition.Add(petition1);
            await _context.SaveChangesAsync();
            return Ok(User);

        }


        [Route("api/FetchPetitionStatus/{id}")]
        [HttpGet]
        public ActionResult<string> GetPetitionStatus(int id)
        {
            var petition = _context.Petition.Find(id);
            if (petition == null)
            {
                return NotFound();
            }
            return Ok(petition.StatusType);
        }




        [HttpGet]
        public IActionResult GetAllPetAccessoryy()
        {
            try
            {
                var pete = _context.Petition.ToList();
                var petitionList = new List<object>();

                foreach (var pet in pete)
                {
                    // Use nullable int for PetitionId if it can be null
                    int? petitionId = pet.PetitionId as int?;

                    var imageUrl = pet.UploadDocumentname != null
                        ? String.Format("{0}://{1}{2}/wwwroot/images/{3}", Request.Scheme, Request.Host, Request.PathBase, pet.UploadDocumentname)
                        : "Image not available";

                    var petData = new
                    {
                        id = petitionId, // Use the nullable int here
                        PetitionDescription = pet.PetitionDescription,
                        AadharNumber = pet.AadharNumber,
                        TalukLocation = pet.TalukLocation,
                        Address = pet.Address,
                        UploadDocument = pet.UploadDocument,
                        UploadDocumentname = pet.UploadDocumentname,
                        StatusType = pet.StatusType,
                        Date= pet.Date,
                        imageUrl = imageUrl
                    };

                    petitionList.Add(petData);
                }

                return Ok(petitionList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }
        [Route("api/GetIndividual/{id}")]
        [HttpGet]
        public IActionResult GetByIndividualUser(int id)
        {
            try
            {
                var user = _context.User.Find(id);
                var pete = _context.Petition.Where(x=>x.User==user).ToList();
                var petitionList = new List<object>();

                foreach (var pet in pete)
                {
                    // Use nullable int for PetitionId if it can be null
                    int? petitionId = pet.PetitionId as int?;

                    var imageUrl = pet.UploadDocumentname != null
                        ? String.Format("{0}://{1}{2}/wwwroot/images/{3}", Request.Scheme, Request.Host, Request.PathBase, pet.UploadDocumentname)
                        : "Image not available";

                    var petData = new
                    {
                        id = petitionId, // Use the nullable int here
                        PetitionDescription = pet.PetitionDescription,
                        AadharNumber = pet.AadharNumber,
                        TalukLocation = pet.TalukLocation,
                        Address = pet.Address,
                        UploadDocument = pet.UploadDocument,
                        UploadDocumentname = pet.UploadDocumentname,
                        StatusType = pet.StatusType,
                        Date=pet.Date,
                        imageUrl = imageUrl
                    };

                    petitionList.Add(petData);
                }

                return Ok(petitionList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
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



        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdatePetitionForm(int id, [FromForm] Petitionformdto petitionFormDto)
        //{
        //    // Retrieve the existing petition form from the database
        //    var petitionToUpdate = await _context.Petition.FindAsync(id);
        //    if (petitionToUpdate == null)
        //    {
        //        return NotFound();
        //    }

        //    // Check if a new document is provided
        //    if (petitionFormDto.UploadDocument != null)
        //    {
        //        // Generate a unique file name for the new document
        //        var uniqueFileName = $"{Guid.NewGuid()}_{petitionFormDto.UploadDocument.FileName}";

        //        // Save the new document to the designated folder
        //        var uploadsFolder = Path.Combine(_environment.WebRootPath, "Documents");
        //        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await petitionFormDto.UploadDocument.CopyToAsync(stream);
        //        }

        //        // Update the document name in the database
        //        petitionToUpdate.UploadDocumentname = uniqueFileName;
        //    }

        //    // Update individual properties if provided
        //    if (!string.IsNullOrEmpty(petitionFormDto.PetitionDescription))
        //    {
        //        petitionToUpdate.PetitionDescription = petitionFormDto.PetitionDescription;
        //    }

        //    if (petitionFormDto.AadharNumber != 0)
        //    {
        //        petitionToUpdate.AadharNumber = petitionFormDto.AadharNumber;
        //    }

        //    if (!string.IsNullOrEmpty(petitionFormDto.TalukLocation))
        //    {
        //        petitionToUpdate.TalukLocation = petitionFormDto.TalukLocation;
        //    }

        //    if (!string.IsNullOrEmpty(petitionFormDto.PetitionStatus))
        //    {
        //        petitionToUpdate.PetitionStatus = petitionFormDto.PetitionStatus;
        //    }

        //    if (!string.IsNullOrEmpty(petitionFormDto.Address))
        //    {
        //        petitionToUpdate.Address = petitionFormDto.Address;
        //    }

        //    // Save the changes to the database
        //    _context.SaveChanges();

        //    // Return a success response, possibly with the updated petition form data
        //    return Ok(petitionToUpdate);
        //}




    }
}
