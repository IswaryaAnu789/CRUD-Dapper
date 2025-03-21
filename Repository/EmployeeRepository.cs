using Dapper;
using Dapperempdetails.Model;
using Dapperempdetails.Repository.Interface;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapperempdetails.Responses;

namespace Dapperempdetails.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _db;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(IConfiguration configuration, ILogger<EmployeeRepository> logger)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            _logger = logger;
        }


        public List<Employee> GetAllEmployees()
        {
           
                string sql = "select id,name,age,job,phoneno from employee where isactive=1";
                List<Employee> employees = _db.Query<Employee>(sql).ToList();
            return employees;

        }

      
        public Employee GetbyEmployeeID(int id)
        {
            
            string sql = "select id,name,age,job,phoneno from employee where id=@id";
            Employee employee = _db.Query<Employee>(sql, new {@id=id}).SingleOrDefault() ?? new Employee();
            return employee;

        }
        public Baseresponse AddEmployee(Employee employee)
        {
            try
            {
                string sql = "INSERT INTO employee (name,age,job,phoneno) values (@name,@age,@job,@phoneno)" + "select cast(scope_identity() as INT)";
                int id = _db.Query<int>(sql, new
                {
                    @name = employee.Name,
                    @age = employee.Age,
                    @job = employee.Job,
                    @phoneno = employee.Phoneno,
                    @isactive = employee.Isactive,
                }).SingleOrDefault();

                return new Baseresponse
                {
                    Status = "Success",
                    Message = "Employee added successfully",
                    Inserted = 1,
                    Deleted = 0
                };
            }
            
            catch (Exception ex)
            {
                _logger.LogError("Error occured while creating employee" + ex.Message);
                return new Baseresponse
                {
                    Status = "Error",
                    Message = ex.Message,
                    Inserted = 0,
                    Deleted = 0
                };
            }
            
        }

        public Baseresponse DeleteEmployee(int id)
        {
              
            string sql = "update employee set isactive=0 OUTPUT DELETED.id  where id=@id";
            var affected = _db.Query<int>(sql, new { id }).SingleOrDefault();

            return new Baseresponse
            {
                Status = affected > 0 ? "Success" : "Failure",
                Message = affected > 0 ? "Employee Deleted Successfully" : "Failure is deleting the employee",
                Inserted = 0,
                Deleted = affected
            };
        }



        public Baseresponse UpdateEmployee(Employee employee)
        {
                
                string sql = "update employee set name = @name,age=@age,job=@job,phoneno=@phoneno where id = @id and isactive=1";
               var updated = _db.Execute(sql, employee);

            return new Baseresponse
            {
                Status = updated > 0 ? "Success" : "Failure",
                Message = updated > 0 ? "Successfully updated" : "Failure in updatation",
                Inserted = 0,
                Deleted = updated
            };

        }
    }
}
