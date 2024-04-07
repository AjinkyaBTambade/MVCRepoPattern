

using System.Data;
using MySql.Data.MySqlClient;
using Core.Repositories.Interfaces;
using Core.Models;
namespace Core.Repositories;
public class EmployeeRepository : IEmployeeRepository{



   private static string connectionString = string.Empty;
    static EmployeeRepository()
    {
        connectionString = "server=localhost;port=3306;user=root;password=password;database=transflower";
    }

    public  List<Employee> GetAllEmployees()
    {
        List<Employee> employees = new List<Employee>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = connectionString;

        MySqlCommand command = new MySqlCommand();
        command.CommandText = "SELECT * FROM employees";
        command.Connection = con;

        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
        DataSet dataSet = new DataSet();
        try
        {
            dataAdapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            foreach (DataRow dataRow in dataTable.Rows)
            {
                int id = int.Parse(dataRow["id"].ToString());
                string firstName = dataRow["firstname"].ToString();
                string lastName = dataRow["lastname"].ToString();
                string email = dataRow["email"].ToString();
                string address = dataRow["address"].ToString();
                string password = dataRow["password"].ToString();
                int managerId = int.Parse(dataRow["managerid"].ToString());
                int deptId = int.Parse(dataRow["deptid"].ToString());

                Employee employee = new Employee()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Address = address,
                    Password = password,
                    ManagerId = managerId,
                    DeptId = deptId,

                };
                employees.Add(employee);
            }

        }
        catch (Exception e)
        {
            throw;
        }


        return employees;
    }




    public  Employee GetEmployeeById(int id)
    {
        Employee employee = null;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = connectionString;

        MySqlCommand command = new MySqlCommand();
        command.CommandText = "SELECT * FROM employees";
        command.Connection = con;

        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
        DataSet dataSet = new DataSet();
        try
        {
            dataAdapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            DataColumn[] keyColumn = new DataColumn[1];
            keyColumn[0] = dataTable.Columns["id"];
            dataTable.PrimaryKey = keyColumn;

            DataRow dataRow = dataTable.Rows.Find(id);
            id = int.Parse(dataRow["id"].ToString());
            string firstName = dataRow["firstname"].ToString();
            string lastName = dataRow["lastname"].ToString();
            string email = dataRow["email"].ToString();
            string address = dataRow["address"].ToString();
            string password = dataRow["password"].ToString();
            int managerId = int.Parse(dataRow["managerid"].ToString());
            int deptId = int.Parse(dataRow["deptid"].ToString());

            employee = new Employee()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Address = address,
                Password = password,
                ManagerId = managerId,
                DeptId = deptId,

            };
        }
        catch (Exception e)
        {
            throw;
        }
        return employee;
    }

    public  bool InsertEmployee(Employee emp)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = connectionString;

        MySqlCommand command = new MySqlCommand();
        command.CommandText = "SELECT * FROM employees";
        command.Connection = con;

        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
        DataSet dataSet = new DataSet();
        try
        {
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            DataRow row = dataTable.NewRow();
            row["id"] = emp.Id;
            row["firstname"] = emp.FirstName;
            row["lastname"] = emp.LastName;
            row["email"] = emp.Email;
            row["address"] = emp.Address;
            row["password"] = emp.Password;
            row["deptid"] = emp.DeptId;
            row["managerid"] = emp.ManagerId;
            dataTable.Rows.Add(row);
            dataAdapter.Update(dataSet);
            status = true;
        }
        catch (Exception e)
        {
            throw;
        }
        return status;
    }


    public  bool UpdateEmployee(Employee emp)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = connectionString;

        MySqlCommand command = new MySqlCommand();
        command.CommandText = "SELECT * FROM employees";
        command.Connection = con;

        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
        DataSet dataSet = new DataSet();
        try
        {
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            DataColumn[] keyColum = new DataColumn[1];
            keyColum[0] = dataTable.Columns["id"];
            dataTable.PrimaryKey = keyColum;

            DataRow row = dataTable.Rows.Find(emp.Id);
            row["firstname"] = emp.FirstName;
            row["lastname"] = emp.LastName;
            row["email"] = emp.Email;
            row["address"] = emp.Address;
            row["password"] = emp.Password;
            row["managerid"] = emp.ManagerId;
            row["deptid"] = emp.DeptId;
            dataAdapter.Update(dataSet);
            status = true;
        }
        catch (Exception e)
        {
            throw;
        }
        return status;
    }

    public  bool DeleteEmployee(int id)
    {
        bool status = false;

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = connectionString;

        MySqlCommand command = new MySqlCommand();
        command.CommandText = "select * from employees";
        command.Connection = con;

        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
        DataSet dataSet = new DataSet();

        try
        {

            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);


            dataAdapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            DataColumn[] keycolumn = new DataColumn[1];
            keycolumn[0] = dataTable.Columns["id"];
            dataTable.PrimaryKey = keycolumn;


            DataRow dataRow = dataTable.Rows.Find(id);
            dataRow.Delete();

            dataAdapter.Update(dataSet);

            status = true;

        }
        catch (Exception e)
        {
            throw;
        }

        return status;
    }
}