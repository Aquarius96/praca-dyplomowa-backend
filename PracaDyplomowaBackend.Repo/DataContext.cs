using Microsoft.EntityFrameworkCore;
using PracaDyplomowaBackend.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Repo
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
    }
}
