using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Repositories.Data;
using Sprout.Exam.Repositories.Interfaces;
using Sprout.Exam.WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Repositories
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<EmployeeDto> FindAll()
        {
            return _dbContext.Employees.Where(e => !e.IsDeleted).ToList();
        }

        public int Save(EmployeeDto employeeDto)
        {
            var employeeList = _dbContext.Employees.ToList();
            var id = employeeList.Count < 1 ? 0 : employeeList.Max(e => e.Id) + 1;

            _dbContext.Employees.Add(employeeDto);
            _dbContext.SaveChanges();
            employeeList = _dbContext.Employees.ToList();

            return id;
        }

        public EmployeeDto FindById(int id)
        {
            return _dbContext.Employees.Find(id);
        }

        public EmployeeDto Update(EditEmployeeDto employeeDto)
        {
            EmployeeDto employee = _dbContext.Employees.Find(employeeDto.Id);
            employee.FullName = employeeDto.FullName;
            employee.Tin = employeeDto.Tin;
            employee.Birthdate = employeeDto.Birthdate.ToString("yyyy-MM-dd");
            employee.EmployeeTypeId = employeeDto.EmployeeTypeId;
            _dbContext.SaveChanges();
            return employee;
        }

        public int Delete(int id)
        {
            EmployeeDto employee = _dbContext.Employees.Find(id);
            employee.IsDeleted = true;
            _dbContext.SaveChanges();
            return employee.Id;
        }
    }
}
