using Sprout.Exam.Repositories.Data;
using Sprout.Exam.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Repositories
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PayrollRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public double Compute()
        {
            // 
            return 0;
        }
    }
}
