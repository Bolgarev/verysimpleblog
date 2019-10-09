using DBRepository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DBRepository.Factory
{
    public class DesignTimeRepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            var repositoryFactory = new RepositoryContextFactory();
            return repositoryFactory.CreateDbContext(connectionString);
        }
    }
}
