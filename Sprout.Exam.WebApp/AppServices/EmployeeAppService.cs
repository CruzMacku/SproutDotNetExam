using Sprout.Exam.AppServices.Interfaces;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.AppServices
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeAppService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IList<EmployeeDto> FindAll()
        {
            return _employeeRepository.FindAll();
        }

        public int Save(EmployeeDto employeeDto)
        {
            return _employeeRepository.Save(employeeDto);
        }

        public EmployeeDto FindById(int id)
        {
            return _employeeRepository.FindById(id);
        }

        public EmployeeDto Update(EditEmployeeDto editEmployeeDto)
        {
            return _employeeRepository.Update(editEmployeeDto);
        }

        public int Delete(int id)
        {
            return _employeeRepository.Delete(id);
        }
    }
}
