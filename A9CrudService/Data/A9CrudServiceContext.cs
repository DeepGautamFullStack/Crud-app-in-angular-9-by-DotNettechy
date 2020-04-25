using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using A9CrudService.Model;

namespace A9CrudService.Models
{
    public class A9CrudServiceContext : DbContext
    {
        public A9CrudServiceContext (DbContextOptions<A9CrudServiceContext> options)
            : base(options)
        {
        }

        public DbSet<A9CrudService.Model.Registration> Registration { get; set; }
    }
}
