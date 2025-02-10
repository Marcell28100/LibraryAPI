using LibraryDolgozat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryDolgozat.Controllers
{
    [Route("Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        //GET

        [HttpGet("get")]

        public async Task<ActionResult<Book>> Get()
        {
            return Ok(await _context.Books.ToListAsync());
        }
        //GET ID

        [HttpGet("get/{id}")]

        public async Task<ActionResult<Book>> GetID(int id)
        {
            
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        //POST

        [HttpPost]
        public async Task<ActionResult<Book>> Post(CreateBookDto createBookDto)
        {
            var book = new Book
            {
                Title = createBookDto.Title,
                Author = createBookDto.Author,
                PublishedYear = createBookDto.PublishedYear,
                Genre = createBookDto.Genre,
                Price = createBookDto.Price

            };

            if (book != null)
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                return StatusCode(201, book);
            }

            return BadRequest();
        }

        //PUT
        //DELETE
    }
}
