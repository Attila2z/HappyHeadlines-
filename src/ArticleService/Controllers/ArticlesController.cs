using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArticleService.Data;
using ArticleService.Models;

namespace ArticleService.Controllers
{
    [ApiController]
    [Route("articles")]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleDbContext _context;

        public ArticlesController(ArticleDbContext context)
        {
            _context = context;
        }

        // CREATE — POST /articles
        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] ArticleRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return BadRequest("Field 'title' is required.");

            if (string.IsNullOrWhiteSpace(request.Content))
                return BadRequest("Field 'content' is required.");

            if (string.IsNullOrWhiteSpace(request.Author))
                return BadRequest("Field 'author' is required.");

            var article = new Article
            {
                Title   = request.Title,
                Content = request.Content,
                Author  = request.Author
            };

            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArticle), new { id = article.Id }, article);
        }

        // READ ALL — GET /articles
        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _context.Articles.ToListAsync();
            return Ok(articles);
        }

        // READ ONE — GET /articles/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
                return NotFound($"Article with id={id} was not found.");

            return Ok(article);
        }

        // UPDATE — PUT /articles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, [FromBody] ArticleRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return BadRequest("Field 'title' is required.");

            if (string.IsNullOrWhiteSpace(request.Content))
                return BadRequest("Field 'content' is required.");

            if (string.IsNullOrWhiteSpace(request.Author))
                return BadRequest("Field 'author' is required.");

            var article = await _context.Articles.FindAsync(id);

            if (article == null)
                return NotFound($"Article with id={id} was not found.");

            article.Title   = request.Title;
            article.Content = request.Content;
            article.Author  = request.Author;

            await _context.SaveChangesAsync();

            return Ok(article);
        }

        // DELETE — DELETE /articles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
                return NotFound($"Article with id={id} was not found.");

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}