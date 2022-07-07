using CurdAppWithStoredProcedure.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CurdAppWithStoredProcedure.Services
{
    public class StudentServices :IStudentService
    {
        private readonly IConfiguration _configuration;
        public StudentServices(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("conn");
            providerName = "System.Data.SqlClient";
        }
        public string ConnectionString { get; }
        public string providerName { get; }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }
        public string InsertStudent(Student model)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var student = dbConnection.Query<List<Student>>("InsertStudentRecore", model, commandType: CommandType.StoredProcedure).ToList();
                dbConnection.Close();
            }
            return "";
        }
        public List<Student> GetStudentsList()
        {
            List<Student> result = new List<Student>();
            try
            {
                using(IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    result = dbConnection.Query<Student>("GetStudentsList", commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return result;
                }
            }
            catch(Exception ex)
            {
                string errorMsg = ex.Message;
                return result;
            }
        }
    }

    public interface IStudentService
    {
       public string InsertStudent(Student model);
        public List<Student> GetStudentsList();
    }
}
