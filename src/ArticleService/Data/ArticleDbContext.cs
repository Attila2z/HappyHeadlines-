// =============================================================================
// Data/ArticleDbContext.cs
// =============================================================================
// This REPLACES ArticleDatabase.cs from before.
//
// WHAT IS A DbContext?
//   It's the Entity Framework Core class that:
//     1. Represents your database connection
//     2. Translates C# code into SQL automatically
//     3. Manages your tables as C# collections (DbSet)
//
// You never write SQL like "SELECT * FROM articles" —
// EF Core does that for you. You just write C# like:
//     _context.Articles.ToList()
//     _context.Articles.Find(id)
// =============================================================================

using Microsoft.EntityFrameworkCore;
using ArticleService.Models;

namespace ArticleService.Data
{
    public class ArticleDbContext : DbContext
    {
        // The constructor receives options (like the connection string)
        // from Program.cs via Dependency Injection
        public ArticleDbContext(DbContextOptions<ArticleDbContext> options)
            : base(options)
        {
        }

        // DbSet = a "table". EF Core creates an "Articles" table in PostgreSQL.
        // You use this like a list:
        //   _context.Articles.Add(...)
        //   _context.Articles.Find(id)
        //   _context.Articles.ToList()
        public DbSet<Article> Articles { get; set; }
    }
}