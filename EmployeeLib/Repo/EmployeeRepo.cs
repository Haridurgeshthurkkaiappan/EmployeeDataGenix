using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using EmployeeLib.Model;

namespace EmployeeLib.Repo
{
    public class EmployeeRepo
    {
        public readonly string connectionString;



        public EmployeeRepo()
        {
            connectionString = @"Data source=DESKTOP-UCPA9BN;Initial catalog=EmployeeData;User Id=sa;Password=Anaiyaan@123";
        }

        public void InsertEmployeeData(EmployeeModel emp)
        {

            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                con.Execute($" exec insertemployeedata'{emp.Name}', '{emp.DateOfBirth.ToString("MM-dd-yyyy")}','{emp.Experience}',{emp.Phonenumber},'{emp.EmailAddress}'");

                con.Close();

            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public EmployeeModel GetEmployeeData(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                var connection = new SqlConnection(connectionString);
                con.Open();
                var Employee = connection.QueryFirst<EmployeeModel>($" exec GetemployeedatabyID {id} ");
                con.Close();



                return Employee;


            }

            catch (SqlException er)
            {
                throw;
            }
            catch (Exception r)
            {
                throw r;
            }
        }

        public List<EmployeeModel> GetEmployeeData()
        {
            try
            {
                List<EmployeeModel> constrain = new List<EmployeeModel>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                constrain = connection.Query<EmployeeModel>($" exec Getemployeedata").ToList();
                connection.Close();

                return constrain;


            }

            catch (SqlException er)
            {
                throw;
            }
            catch (Exception r)
            {
                throw r;
            }
        }

        public void UpdateEmployeeData(EmployeeModel emp)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                con.Execute($" exec Updateemployeedata '{emp.Name}', '{emp.DateOfBirth.ToString("MM-dd-yyyy")}','{emp.Experience}',{emp.Phonenumber},'{emp.EmailAddress}',{emp.Empid}");
                con.Close();
            }
            catch (SqlException eu)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteEmployeeData(int id)
        {
            try
            {


                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                con.Execute($"  exec DeleteEmployeeData { id}");

                con.Close();

            }
            catch (SqlException ed)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}


      