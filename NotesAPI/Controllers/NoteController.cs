using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesAPI.LocalControllers;
using NotesAPI.Models;
using WildNature_Back.Context;

namespace NotesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly NoteLocalRepository notesRepo;

        public NoteController(NoteLocalRepository noteLocal)
        {
            notesRepo = noteLocal;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Note model)
        {
            var result = await notesRepo.Create(model);

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
            var result = await notesRepo.Remove(id);

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
            var result = await notesRepo.Select();

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("SelectNote")]
        public async Task<IActionResult> SelectNotes(string header)
        {
            var result = await notesRepo.FindByName(header);

            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(int id, string name)
        {
            var result = await notesRepo.Update(id, name);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
