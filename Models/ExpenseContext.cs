using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timu_Vlad_Lab5.Models;

namespace Timu_Vlad_Lab5.Models
{
    public class ExpenseContext : DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options)
 : base(options)
        {
        }
        public DbSet<Expenses> Expense { get; set; }
       
        public DbSet<Budget> Budget { get; set; }

    }
}
