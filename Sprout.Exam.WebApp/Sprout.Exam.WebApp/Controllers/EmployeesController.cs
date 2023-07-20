using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.WebApp.Data;
using Sprout.Exam.AppServices.Interfaces;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private IEmployeeAppService _employeeAppService;
        private IPayrollAppService _payrollAppService;

        public EmployeesController(IEmployeeAppService employeeAppService, IPayrollAppService payrollAppService)
        {
            _employeeAppService = employeeAppService;
            _payrollAppService = payrollAppService;
        }
        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await Task.FromResult(_employeeAppService.FindAll()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await Task.FromResult(_employeeAppService.FindById(id));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Refactor this method to go through proper layers and update changes to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditEmployeeDto editEmployeeDto)
        {
            try
            {

                var result = await Task.FromResult(_employeeAppService.Update(editEmployeeDto));
                if (result == null) return NotFound();

                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Refactor this method to go through proper layers and insert employees to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeDto input)
        {
            try
            {
                var id = await Task.FromResult(_employeeAppService.Save(
                new EmployeeDto
                {
                    Birthdate = input.Birthdate.ToString("yyyy-MM-dd"),
                    FullName = input.FullName,
                    Tin = input.Tin,
                    EmployeeTypeId = input.EmployeeTypeId
                }));

                return Created($"/api/employees/{id}", id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Refactor this method to go through proper layers and perform soft deletion of an employee to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await Task.FromResult(_employeeAppService.Delete(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        /// <summary>
        /// Refactor this method to go through proper layers and use Factory pattern
        /// </summary>
        /// <param name="id"></param>
        /// <param name="absentDays"></param>
        /// <param name="workedDays"></param>
        /// <returns></returns>
        [HttpPost("calculate/{id}/{absentDays}/{workedDays}")]
        public async Task<IActionResult> Calculate(int id, decimal absentDays = 0, decimal workedDays = 0)
        {
            try
            {
                var result = await Task.FromResult(_employeeAppService.FindById(id));

                if (result == null) return NotFound();

                return Ok(string.Format("{0:0.##}", _payrollAppService.Compute(result, absentDays, workedDays)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
