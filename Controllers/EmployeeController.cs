using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTechTestAPI.Models;
using MTechTestAPI.Repositories;

namespace MTechTestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //private readonly MTechTestIMDb _context;
        private readonly MTechTestMYSQL _context;
        //private readonly MTechTestSQLSERVER _context;

        public EmployeeController(MTechTestMYSQL context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult CreateEmployee(Employee employee)
        {
            if(employee.ID == 0)
                try
                {
                    _context.Employees.Add(employee);
                }catch (Exception ex){
                    return new JsonResult(BadRequest(ex.Message));
                }
            else return new JsonResult(BadRequest());

            try
            {
                _context.SaveChanges();
            }catch (Exception ex){
                return new JsonResult(BadRequest(ex.Message));
            }

            return new JsonResult(Ok(employee));
        }

        [HttpPut("{id}")]
        public JsonResult ModifyEmployee(long id, Employee employee)
        {
            if (id != employee.ID)
            {
                return new JsonResult(BadRequest());
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                 _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Employees.Find(id) == null)
                {
                    return new JsonResult(NotFound());
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult(Ok(employee));
        }


        [HttpGet("{id}")]
        public JsonResult GetEmployeeByID(int id)
        {
            var result = _context.Employees.Find(id);

            if( result == null ) return new JsonResult(NotFound());

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteEmployee(int ID)
        {
            var result = _context.Employees.Find(ID);

            if( result == null) return new JsonResult(NotFound());

            _context.Employees.Remove(result);

            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        [HttpGet]
        public JsonResult GetAllEmployees()
        {
            var result = _context.GetEmployeesOrderedByBornDate();
            return new JsonResult(Ok(result));
        }

        [HttpGet("/search/{name}")]
        public JsonResult GetAllEmployeesWhoHave(string name)
        {
            var result = _context.GetEmployeesWhoHave(name);
            return new JsonResult(Ok(result));
        }
    }
}
