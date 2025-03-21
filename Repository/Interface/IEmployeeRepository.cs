using Dapperempdetails.Responses;
using Dapperempdetails.Controllers;
using Dapperempdetails.Model;


namespace Dapperempdetails.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Employee GetbyEmployeeID(int id);

        List<Employee> GetAllEmployees();

        Baseresponse AddEmployee(Employee employee);

        Baseresponse UpdateEmployee(Employee employee);


        Baseresponse DeleteEmployee(int id);
      
    }
}
