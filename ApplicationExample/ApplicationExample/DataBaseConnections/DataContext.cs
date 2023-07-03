
namespace ApplicationExample.DataBaseConnections
{
    using ApplicationExample.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web;

    public class DataContext
    {
        public string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
                employee.Id = reader.GetInt32(0);
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

        public List<Employee> get()
        {
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
                employee.Id = reader.GetInt32(0);
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

            SqlDataAdapter adapter = new SqlDataAdapter(query,connectionString);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }

            return "No data Found";

        }

        public string deleteEmployee(int id)
        {
            SqlConnection sqlConnector = new SqlConnection(connectionString) ;
            sqlConnector.Open();
            string query = $"delete from employeedata where id={id}";
            SqlCommand cmd = new SqlCommand(query, sqlConnector);


            

            cmd.CommandText = query;
            cmd.Connection = sqlConnector;
            cmd.CommandType = System.Data.CommandType.Text;


            int result = cmd.ExecuteNonQuery();


            if (sqlConnector.State == System.Data.ConnectionState.Open)
            {


                sqlConnector.Close();

            }
            if (result >= 1)
            {
                return "Value Deleted";
            }
            return "Not Found";
        }

        public string updateEmployee(int id, Employee emp)
        {
            SqlConnection sqlConnector = new SqlConnection(connectionString);
            sqlConnector.Open();
            string query = $"update employeedata set name='{emp.name}',height={emp.height},weight={emp.weight},officefloorno={emp.officeFloor} where id={id}";
            SqlCommand cmd = new SqlCommand(query, sqlConnector);




            cmd.CommandText = query;
            cmd.Connection = sqlConnector;
            cmd.CommandType = System.Data.CommandType.Text;


            int result = cmd.ExecuteNonQuery();


            if (sqlConnector.State == System.Data.ConnectionState.Open)
            {


                sqlConnector.Close();

            }
            if (result >= 1)
            {
                return "Value Updated";
            }
            return "Not Found";
        }
    

        public List<ElevatorLog> getElevatorLogList()
        {


            SqlConnection sqlConnector = new SqlConnection(connectionString);
            sqlConnector.Open();

            string query = $"select * from liftlog ";

            SqlCommand cmd = new SqlCommand(query, sqlConnector);

            cmd.CommandText = query;
            cmd.Connection = sqlConnector;
            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();

            List<ElevatorLog> log = new List<ElevatorLog>();

            while (reader.Read())
            {
                ElevatorLog logItem = new ElevatorLog();
                logItem.id = reader.GetInt32(0);
                logItem.floorno = reader.GetInt32(1); 
                logItem.weight = reader.GetInt32(2);
                logItem.time = reader.GetDateTime(3);
                log.Add(logItem);
            }
            if (sqlConnector.State == System.Data.ConnectionState.Open)
            {


                sqlConnector.Close();

            }

            return log;
        }

        public ElevatorLog getElevatorLogById(int id) {

            SqlConnection sqlConnector = new SqlConnection(connectionString);

            sqlConnector.Open();

            string query = $"select * from liftlog where Id={id}";

            SqlCommand cmd = new SqlCommand(query, sqlConnector);

            cmd.CommandText = query;
            cmd.Connection = sqlConnector;
            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();

            ElevatorLog log = new ElevatorLog();    

            while (reader.Read())
            {
                log.id = reader.GetInt32(0);
                log.floorno = reader.GetInt32(1);
                log.weight = reader.GetInt32(2);
                log.time = reader.GetDateTime(3);
            }
            if (sqlConnector.State == System.Data.ConnectionState.Open)
            {


                sqlConnector.Close();

            }

            return log;



        }

        public string addLiftlog(ElevatorLog log)
        {
            log.time=DateTime.Now;
            SqlConnection sqlConnector = new SqlConnection(connectionString);

            sqlConnector.Open();
            string query = $"insert into liftlog values({log.floorno},{log.weight},'{log.time}')";
            SqlCommand cmd = new SqlCommand(query, sqlConnector);

            cmd.CommandText = query;
            cmd.Connection = sqlConnector;
            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                cmd.ExecuteNonQuery();
            }catch (Exception ex)
            {
                return "Not inserted";

            }


            if (sqlConnector.State == System.Data.ConnectionState.Open)
            {


                sqlConnector.Close();

            }

            return "Values inserted";


        }
    }
}