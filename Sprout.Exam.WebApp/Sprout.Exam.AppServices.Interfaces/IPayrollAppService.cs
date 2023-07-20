using Sprout.Exam.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.AppServices.Interfaces
{
    public interface IPayrollAppService
    {
        decimal Compute(EmployeeDto employeeDto, decimal absentDays, decimal workedDays);
    }
}
