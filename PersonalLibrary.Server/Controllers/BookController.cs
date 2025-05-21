using Microsoft.AspNetCore.Mvc;
using PersonalLibrary.DAL.DTO;
using PersonalLibrary.DAL.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PersonalLibrary.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        public IBookDAL BookDAL { get; set; }

        public BookController(IBookDAL bookDAL)
        {
            BookDAL = bookDAL;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetById(int id)
        {
            BookDTO? book = await BookDAL.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        //[HttpGet]
        //public async Task<ActionResult<int>> GetByIdTry(int id)
        //{
        //    //return await BookDAL.GetByIdAsync(id);

        //    var book = await BookDAL.GetByIdAsync(id);
        //    //if (book == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    return Ok(3);
        //}

        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetAll()
        {
            return Ok(await BookDAL.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] BookDTO bookDTO)
        {
            int newId = await BookDAL.CreateAsync(bookDTO);

            return CreatedAtAction(nameof(GetById), new { id = newId }, newId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookDTO bookDTO)
        {
            if (id != bookDTO.Id)
                return BadRequest("ID mismatch");

            await BookDAL.UpdateAsync(bookDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await BookDAL.DeleteAsync(id);
            return Ok();
        }
    }
}
