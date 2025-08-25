using EShopper.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopper.Comment.Context
{
    public class CommentDbContext : DbContext
    {
        public CommentDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
