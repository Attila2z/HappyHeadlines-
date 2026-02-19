// =============================================================================
// Models/Article.cs
// =============================================================================
// Same model as before, but now with Entity Framework "annotations".
// These attributes tell EF Core how to create the database table.
// =============================================================================

using System.ComponentModel.DataAnnotations;

namespace ArticleService.Models
{
    public class Article
    {
        // [Key] tells EF Core this is the Primary Key
        // EF Core will auto-increment it in PostgreSQL
        [Key]
        public int Id { get; set; }

        // [Required] means this column cannot be NULL in the database
        // [MaxLength] sets the column size in the database
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }
    }

    // DTO — used for Create and Update requests (no Id from the client)
    public class ArticleRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Author { get; set; }
    }
}