using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesAPI.LocalControllers;
using NotesAPI.Models;
using WildNature_Back.Context;

namespace NotesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserLocalRepository usersRepo;

        public UserController(UserLocalRepository userLocal)
        {
            usersRepo = userLocal;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(User user)
        {
            var result = await usersRepo.Create(user);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await usersRepo.Remove(id);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("Select")]
        public async Task<IActionResult> Select()
        {
            var result = await usersRepo.Select();

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Authroization")]
        public async Task<IActionResult> AuthorizationUser(User user)
        {
            var result = usersRepo.Authorization(user.Name, user.Password);
            if (result != null)
            {
                HttpContext.Session.SetString("Username", user.Name);
                return Ok(result);
            }
            return BadRequest();
        }        
        
        [HttpGet]
        [Route("AuthroizationName")]
        public async Task<IActionResult> getAuthorizationUser()
        {
            var username = HttpContext.Session.GetString("Username");
            if (!string.IsNullOrEmpty(username))
            {
                var result = await usersRepo.FindByName(username);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(int id, string name)
        {
            var result = await usersRepo.Update(id, name);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
