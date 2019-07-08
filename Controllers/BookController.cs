using  Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BookStoreMySQL.Models;


namespace BookStoreMySQL.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController:ControllerBase
    {

        private readonly BooksDbContext _dbContext;

        public BookController(BooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> get()
            => await _dbContext.Book.ToListAsync();
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> getBookById(int id) 
            => await _dbContext.Book.FindAsync(id);

        [HttpPost]
        public async Task<ActionResult> create([FromBody]Book bookIn)
        {
            await _dbContext.Book.AddAsync(bookIn);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]        
        public async Task<ActionResult> delete(int id)
        {
            Book tempBook = await _dbContext.Book.FindAsync(id);
            if (tempBook is null)
            {
                return NotFound();
            }
            _dbContext.Book.Remove(tempBook);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        
        [HttpPut("{id}")]        
        public async Task<ActionResult> update(int id, [FromBody] Book book)
        {
            if (book.Id != id)
            {
                return NotFound();
            }

            _dbContext.Entry(book).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}