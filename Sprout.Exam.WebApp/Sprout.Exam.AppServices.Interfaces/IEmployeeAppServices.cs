using Sprout.Exam.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.AppServices.Interfaces
{
    public interface IEmployeeAppService
    {
        IList<EmployeeDto> FindAll();

        EmployeeDto FindById(int id);

        int Save(EmployeeDto employeeDto);

        EmployeeDto Update(EditEmployeeDto editEmployeeDto);

        int Delete(int id);
    }
}