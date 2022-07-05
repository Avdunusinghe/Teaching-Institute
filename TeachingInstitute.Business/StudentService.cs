using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingInstitute.Business.Interfaces;

namespace TeachingInstitute.Business
{
    public class StudentService : IStudentService
    {
        #region Public Methods
        public bool DeleteStudent(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TIConnection"].ToString();
            var mySqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sqlCommand = new MySqlCommand("", mySqlConnection);
            mySqlConnection.Open();

            try
            {
                sqlCommand.CommandText = "DELETE from student WHERE id = @studentId";

                sqlCommand.Parameters.AddWithValue("@studentId", id);

                sqlCommand.ExecuteScalar();

                
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

                mySqlConnection.Close();

            }

            return true;
        } 
        #endregion
    }
}
