
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetitionManagementSystem.Models;
using PetitionManagementSystem.Controllers;

using System;
using System.Linq.Expressions;
using PetitionManagementSystem.Connection;
using PetitionManagementSystem.Dummy;

namespace PetitionManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly PetitionManagementDBContext context;
        public UserController(PetitionManagementDBContext context)
        {
            this.context = context;
        }



        [HttpPost]
        public async Task<IActionResult> Post(User userfields)
        {
            context.Add(userfields);
            await context.SaveChangesAsync();
            return Ok();

        }


        [HttpPost]
        public async Task<IActionResult> Signin(Signin emp)
        {
            if (context.Admin.Any(s => s.Email == emp.Email) ||
            context.PetitionHandlers.Any(s => s.Email == emp.Email) ||
            context.User.Any(s => s.Email == emp.Email))
            {
                if (context.Admin.Any(s => s.Email == emp.Email))
                {
                    var admin = context.Admin.FirstOrDefault(s => s.Email == emp.Email);
                    if (admin != null && admin.Password == emp.Password)
                    {
                        return Ok("{\"emailstatus\":true,\"passwordstatus\":true,\"Role\":\"Admin\"}");
                    }
                    return Ok("{\"emailstatus\":true,\"passwordstatus\":false,\"Role\":\"Admin\"}");
                }

                if (context.PetitionHandlers.Any(s => s.Email == emp.Email))
                {
                    var petitionHandler = context.PetitionHandlers.FirstOrDefault(s => s.Email == emp.Email);
                    if (petitionHandler != null && petitionHandler.Password == emp.Password)
                    {
                        return Ok("{\"emailstatus\":true,\"passwordstatus\":true,\"Role\":\"PetitionHandler\"}");
                    }
                    return Ok("{\"emailstatus\":true,\"passwordstatus\":false,\"Role\":\"PetitionHandler\"}");
                }

                if (context.User.Any(s => s.Email == emp.Email))
                {
                    var user = context.User.FirstOrDefault(s => s.Email == emp.Email);
                    if (user != null && user.Password == emp.Password)
                    {
                       return Ok("{\"emailstatus\":\"true\",\"passwordstatus\":true\",\"Role\":\"User\"}");
                    }
                    return Ok("{\"emailstatus\":true,\"passwordstatus\":false,\"Role\":\"User\"}");
                }

                return Ok("{\"emailstatus\":true,\"passwordstatus\":false,\"Role\":\"User\"}");
            }
            else
            {
                return Ok("{\"emailstatus\":false,\"passwordstatus\":false}");
            }
        }






    }

        


    }




    

    