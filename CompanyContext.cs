using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Company
{
    class CompanyContext : DbContext
    {
        public CompanyContext(string name) : base(name) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employer> Employer { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
