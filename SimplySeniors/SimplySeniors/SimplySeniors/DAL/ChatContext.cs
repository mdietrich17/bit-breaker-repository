
using SimplySeniors.Models;

namespace SimplySeniors.DAL
{

    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    public class ChatContext : DbContext
    {
        public ChatContext() 
            //: base("name=ChatContext")
        {
        }

        public static ChatContext Create()
        {
            return new ChatContext();
        }

        public DbSet<User> Users { get; set; }
    }
}