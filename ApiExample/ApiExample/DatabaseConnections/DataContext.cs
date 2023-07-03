using ApiExample.Models;

namespace ApiExample.DatabaseConnections
{
    using Microsoft.Data.SqlClient;
    using Newtonsoft.Json;
    using System.Data;
    public class DataContext
    {

        public string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public Employee getEmployeeById(int id)
        {
            SqlConnection sqlConnector = new SqlConnection(connectionString);

            sqlConnector.Open();

            string query = $"select * from employeedata where Id={id}";

            SqlCommand cmd = new SqlCommand(query, sqlConnector);

            cmd.CommandText = query;
            cmd.Connection = sqlConnector;
            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();

            Employee employee = new Employee();

            while (reader.Read())
            {
                employee.name = reader.GetString(1);
                employee.height = reader.GetInt32(2);
                employee.weight = reader.GetInt32(3);
                employee.officeFloor = reader.GetInt32(4);
            }
            if (sqlConnector.State == System.Data.ConnectionState.Open)
            {


                sqlConnector.Close();

            }

            return employee;

        }

        public List<Employee> get() {
            SqlConnection sqlConnector = new SqlConnection(connectionString);

            sqlConnector.Open();

            string query = $"select * from employeedata ";

            SqlCommand cmd = new SqlCommand(query, sqlConnector);

            cmd.CommandText = query;
            cmd.Connection = sqlConnector;
            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();

            List<Employee> employees = new List<Employee>();    

            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.name = reader.GetString(1);
                employee.height = reader.GetInt32(2);
                employee.weight = reader.GetInt32(3);
                employee.officeFloor = reader.GetInt32(4);
                employees.Add(employee);
            }
            if (sqlConnector.State == System.Data.ConnectionState.Open)
            {


                sqlConnector.Close();

            }

            return employees;


        }

        public void addEmployee(Employee employee)
        {
            SqlConnection sqlConnector = new SqlConnection(connectionString);

            sqlConnector.Open();
            string query = $"insert into employeedata values('{employee.name}',{employee.weight},{employee.height},{employee.officeFloor})";
            SqlCommand cmd = new SqlCommand(query, sqlConnector);

            cmd.CommandText = query;
            cmd.Connection = sqlConnector;
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.ExecuteNonQuery();


            if (sqlConnector.State == System.Data.ConnectionState.Open)
            {


                sqlConnector.Close();

            }


        }
        public string getEmpByDt()
        {
            SqlConnection sqlConnector = new SqlConnection(connectionString);

            sqlConnector.Open();

            string query = $"select * from employeedata ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }

            return "No data Found";

            

        }
    }
}
