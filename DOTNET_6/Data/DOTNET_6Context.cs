using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DOTNET_6.Models;

namespace DOTNET_6.Data
{
    public class DOTNET_6Context : DbContext
    {
        public DOTNET_6Context (DbContextOptions<DOTNET_6Context> options)
            : base(options)
        {
        }

        public DbSet<DOTNET_6.Models.Book> Book { get; set; } = default!;
    }
}
