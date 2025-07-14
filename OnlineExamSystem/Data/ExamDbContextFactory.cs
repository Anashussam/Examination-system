using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OnlineExamSystem.Data;
using System.IO;

public class ExamDbContextFactory : IDesignTimeDbContextFactory<ExamDbContext>
{
    public ExamDbContext CreateDbContext(string[] args)
    {
        // نقرأ الإعدادات من appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // مهم جداً
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ExamDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);

        return new ExamDbContext(optionsBuilder.Options);
    }
}
