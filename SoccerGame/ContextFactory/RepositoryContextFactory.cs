﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace SoccerGame.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>

{
    public RepositoryContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
        var connectionString = configuration.GetConnectionString("sqlConnection");

        var builder = new DbContextOptionsBuilder<RepositoryContext>()
        .UseSqlServer(connectionString,
         b => b.MigrationsAssembly("SoccerGame"));

        return new RepositoryContext(builder.Options);
    }

}
