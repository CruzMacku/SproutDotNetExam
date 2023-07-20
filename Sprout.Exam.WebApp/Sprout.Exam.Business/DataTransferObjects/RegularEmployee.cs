using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sprout.Exam.Business.DataTransferObjects
{
    public class RegularEmployee : EmployeeDto
    {
        public decimal Salary = 20000;
        public decimal Tax = 0.12m;
        public decimal absentDays { get; set; }

        public decimal GetDailyRate()
        {
            return Salary / 22;
        }

        public decimal GetTaxDeductions()
        {
            return Salary * Tax;
        }
        public RegularEmployee(EmployeeDto employeeDto)
        {
            foreach (PropertyInfo property in employeeDto.GetType().GetProperties())
            {
                if (property.CanWrite)
                {
                    property.SetValue(this, property.GetValue(employeeDto, null), null);
                }
            }
        }
    }
}
