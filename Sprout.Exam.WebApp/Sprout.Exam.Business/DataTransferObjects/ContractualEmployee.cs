using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sprout.Exam.Business.DataTransferObjects
{
    public class ContractualEmployee : EmployeeDto
    {
        public decimal WorkedDays { get; set; }
        public decimal DailyRate = 500m;

        public ContractualEmployee(EmployeeDto employeeDto)
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
