using Sprout.Exam.AppServices.Interfaces;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.AppServices
{

    public class PayrollAppService : IPayrollAppService
    {
        public decimal Compute(EmployeeDto employeeDto, decimal absentDays, decimal workedDays)
        {
            var type = (EmployeeType)employeeDto.EmployeeTypeId;
            switch (type)
            {
                case EmployeeType.Regular:
                    var regularEmployee = new RegularEmployee(employeeDto);
                    regularEmployee.absentDays = absentDays;
                    return ComputeRegularEmployee(regularEmployee);

                case EmployeeType.Contractual:
                    var contructualEmployee = new ContractualEmployee(employeeDto);
                    contructualEmployee.WorkedDays = workedDays;
                    return ComputeContructualEmployee(contructualEmployee);
                default:
                    return 0;
            }
        }

        private decimal ComputeRegularEmployee(RegularEmployee regularEmployee)
        {
            return regularEmployee.Salary - (regularEmployee.absentDays * regularEmployee.GetDailyRate()) - regularEmployee.GetTaxDeductions();
        }

        private decimal ComputeContructualEmployee(ContractualEmployee contructualEmployee)
        {
            return contructualEmployee.WorkedDays * contructualEmployee.DailyRate;
        }
    }
}
