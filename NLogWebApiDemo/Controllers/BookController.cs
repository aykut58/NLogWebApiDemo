using Microsoft.AspNetCore.Mvc;
using NLogWebApiDemo.Contracts;
using NLogWebApiDemo.Repositories;

namespace NLogWebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase 
    {
        private readonly RepositoryContext _context;
        private readonly ILoggerService _logger;
        public BookController(RepositoryContext context, ILoggerService logger)
        {
           _context = context;
           _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllBooks() 
        {
            var books = _context.Books.ToList();
            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetBook([FromRoute(Name ="id")]int id) 
        {
            var book = _context.Books.Where(b => b.Id.Equals(id)).SingleOrDefault();
            if(book == null)
            {
                _logger.LogWarning($"ID'si {id} olan kitap bulunamadı.");
                return NotFound();
            }

            return Ok(book);
        }
    }
}
