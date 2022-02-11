using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Report.Entity.DBContextModel;

namespace Report.Entity
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<PatientDetails> PatientDetails { get; set; } = null!;
        public DbSet<TypeOfTests> TypeOfTest { get; set; } = null!;
        public DbSet<TestResults> TestResult { get; set; } = null!;
        public DbSet<TestSummaries> TestSummary { get; set; } = null!;
        public DbSet<TestReports> TestReport { get; set; } = null!;
        public DbSet<LoginCredential> LoginCredentials { get; set; } = null!;
    }
}
