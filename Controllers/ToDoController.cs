using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListWebApi.Model;
using ToDoListWebApi.Repository;

namespace ToDoListWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ITodListRepo _todorepo;
        public ToDoController(ITodListRepo todorepo)
        {
            _todorepo=todorepo;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var records = await _todorepo.GetAllBookAsync();
            return Ok(records);
        }
        [HttpGet("sort")]
        public async Task<IActionResult> GetInSorted()
        {
            var records = await _todorepo.GetAllBookSortedByDateAsync();
            return Ok(records);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var record = await _todorepo.GetBookByIdAsync(id);
            if (record == null)
            {
                return BadRequest();
            }
            return Ok(record);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] ToDoModel bookmodel)
        {
            var id = await _todorepo.AddBookAsync(bookmodel);
            return CreatedAtAction(nameof(GetBookById), new { id = id, controller = "ToDo" }, id);
        }

       [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] ToDoModel bookmodel, [FromRoute] int id)
        {  // so the controller says that we have to grab the id from the url 
            await _todorepo.UpdateBookAsync(id, bookmodel);
            //  return CreatedAtAction(ameof(GetBookById), new { id = id, controller = "Books" }, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _todorepo.DeleteBookAsync(id);
            return Ok();
        }
       
    }
}
