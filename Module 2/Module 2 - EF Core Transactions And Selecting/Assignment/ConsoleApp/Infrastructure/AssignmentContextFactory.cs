using Assignment.Infrastructure;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Infrastructure
{
    public class AssignmentContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AssignmentContextFactory()
        {
        }

        public AppDbContext CreateDbContext(string[] args)
        {
            return new AppDbContext("Server = (LocalDb)\\MSSQLLocalDB; Database = EFTransactionsDb; Trusted_Connection = True;");
        }
    }
}
