using EShopper.Message.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EShopper.Message.Context
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<UserMessage> UserMessages { get; set; }
    }
}
