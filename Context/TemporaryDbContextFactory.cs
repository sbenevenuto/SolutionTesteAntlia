using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Context
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<SolutionContext>
    {        
        public SolutionContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SolutionContext>();
            builder.UseSqlServer("Server=.\\SQLEXPRESS;Database=WCITesteAntlia;Trusted_Connection=True;MultipleActiveResultSets=true",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(SolutionContext).GetTypeInfo().Assembly.GetName().Name));
            return new SolutionContext(builder.Options);
        }
    }
}
