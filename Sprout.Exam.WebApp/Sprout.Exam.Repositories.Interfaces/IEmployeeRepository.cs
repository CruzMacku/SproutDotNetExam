using Sprout.Exam.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        IList<EmployeeDto> FindAll();

        EmployeeDto Update(EditEmployeeDto editEmployeeDto);

        int Save(EmployeeDto employeeDto);

        EmployeeDto FindById(int id);

        int Delete(int id);
    }
}
