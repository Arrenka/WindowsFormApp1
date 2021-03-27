using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public static class Repository
    {
        public static IEnumerable<Furniture> FuturiesByEmployee(int employeeId)
        {
            using (ApplicationContext _ctx = new ApplicationContext())
            {
                var emp = _ctx.OrgUnits.Include(x => x.Furnitures).First(x => x.Id == employeeId);
                var result = emp.Furnitures;

                return result;
            }
        }

        public static IEnumerable<Furniture> FuturiesByDepartament(int departamentId)
        {
            using (ApplicationContext _ctx = new ApplicationContext())
            {
                var result = new List<Furniture>();
                var departament = _ctx.OrgUnits.First(x => x.Id == departamentId);
                var employees = _ctx.OrgUnits.Include(x => x.Furnitures).Where(x => x.DepartmentId == departament.Id);

                foreach (var employee in employees)
                {
                    result.AddRange(employee.Furnitures);
                }

                return result;
            }
        }

        public static IEnumerable<Furniture> FuturiesByBusinessUnitId(int BusinessUnitId)
        {
            using (ApplicationContext _ctx = new ApplicationContext())
            {
                var result = new List<Furniture>();
                var business = _ctx.OrgUnits.First(x => x.Id == BusinessUnitId);
                var departments = _ctx.OrgUnits.Include(p => p.Furnitures).Where(x => x.BusinessUnitId == business.Id).ToList();

                foreach (var depart in departments)
                {
                    var employees = _ctx.OrgUnits.Include(p => p.Furnitures).Where(x => x.DepartmentId == depart.Id).ToList();

                    foreach (var emp in employees)
                    {
                        result.AddRange(emp.Furnitures);
                    }
                }

                return result;
            }
        }

        public static IEnumerable<EmployeeVM> GetEmployees()
        {
            var result = new List<EmployeeVM>();

            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=inventorydb;Trusted_Connection=True;";
            string sql = $@"SELECT emp.[Name]
                                  ,dep.[Name]
	                              ,bu.[Name]
                              FROM [inventorydb].[dbo].[OrgUnits] emp
                              JOIN OrgUnits dep 
                                ON dep.id = emp.DepartmentId
                              JOIN OrgUnits bu 
                                ON bu.id = dep.BusinessUnitId
                             WHERE emp.DepartmentId is not null";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var employee = new EmployeeVM
                        {
                            FIO = reader.GetString(0),
                            DepartmentName = reader.GetString(1),
                            BusinessUnitName = reader.GetString(2),
                        };
                        result.Add(employee);
                    }
                }
            }

            return result;
        }
    }
}
