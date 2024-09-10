using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyBudget.Data;
using System.IO;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyBudgetContext>
{
    public MyBudgetContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyBudgetContext>();
        optionsBuilder.UseSqlite("Data Source=MyBudget.db");

        return new MyBudgetContext(optionsBuilder.Options);
    }
}
