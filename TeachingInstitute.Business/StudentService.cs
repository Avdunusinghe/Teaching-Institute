using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingInstitute.Business.Interfaces;
using TeachingInstitute.Model;

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

        public Student FillStudentForm(int id)
        {
            var student = new Student();

            var connectionString = ConfigurationManager.ConnectionStrings["TIConnection"].ToString();
            var mySqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sqlCommand = new MySqlCommand("", mySqlConnection);
            MySqlDataReader mySqlDataReader = null;
            mySqlConnection.Open();

            try
            {

                sqlCommand.CommandText = "SELECT id, firstName, lastName, address, mobileNumber, birthday, createdDate FROM student WHERE id = @id";
                sqlCommand.Parameters.AddWithValue("@id", id);

                mySqlDataReader = sqlCommand.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    student.FirstName = mySqlDataReader["firstName"].ToString();
                    student.LastName = mySqlDataReader["lastName"].ToString();
                    student.MobileNumber = mySqlDataReader["mobileNumber"].ToString();
                    student.Address = mySqlDataReader["Address"].ToString();
                    student.BirthDay = mySqlDataReader["birthDay"].ToString();

                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                mySqlDataReader.Close();
                mySqlConnection.Close();
                sqlCommand.Dispose();
            }


            return student;
        }

        public List<Student> GetStudents()
        {
           
            var connectionString = ConfigurationManager.ConnectionStrings["TIConnection"].ToString();
            var mySqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sqlCommand = new MySqlCommand("", mySqlConnection);
            MySqlDataReader mySqlDataReader = null;
            mySqlConnection.Open();
            var studentList = new List<Student>();
            try
            {
               

                sqlCommand.CommandText = "SELECT id, firstName, lastName, address, mobileNumber, birthday, createdDate FROM student ORDER BY createdDate DESC";
                mySqlDataReader = sqlCommand.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    var studentDetails = new Student
                    {
                        Id = int.Parse(mySqlDataReader["id"].ToString()),
                        FirstName = mySqlDataReader["firstName"].ToString(),
                        LastName = mySqlDataReader["lastName"].ToString(),
                        MobileNumber = mySqlDataReader["mobileNumber"].ToString(),
                        Address = mySqlDataReader["Address"].ToString(),
                        BirthDay = mySqlDataReader["birthDay"].ToString(),
                        CreatedDate = DateTime.Parse(mySqlDataReader["createdDate"].ToString()),

                    };

                    studentList.Add(studentDetails);
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                mySqlDataReader.Close();
                mySqlConnection.Close();

            }

            return studentList;

        }

        public StudentSaveResponse SaveStudent(Student student)
        {
            var response = new StudentSaveResponse();

            var connectionString = ConfigurationManager.ConnectionStrings["TIConnection"].ToString();
            var mySqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sqlCommand = new MySqlCommand("", mySqlConnection);
            MySqlDataReader mySqlDataReader = null;
            mySqlConnection.Open();
            string validMobileNumber = string.Empty;
            string message = string.Empty;
            string script = string.Empty;
            string url = string.Empty;

            try
            {
                if (student.Id > 0)
                {
                    sqlCommand.CommandText = "UPDATE student SET firstName = @firstName, lastName = @lastName, address = @address, " +
                                              "mobileNumber = @mobileNumber, birthDay= @birthDay WHERE id = @id";

                    sqlCommand.Parameters.AddWithValue("@id", student.Id);
                    sqlCommand.Parameters.AddWithValue("@firstName", student.FirstName);
                    sqlCommand.Parameters.AddWithValue("@lastName", student.LastName);
                    sqlCommand.Parameters.AddWithValue("@address", student.Address);
                    sqlCommand.Parameters.AddWithValue("@mobileNumber", student.MobileNumber);
                    sqlCommand.Parameters.AddWithValue("@birthDay", DateTime.Parse(student.BirthDay));

                }
                else
                {
                    sqlCommand.CommandText = "SELECT  mobileNumber From student WHERE mobileNumber = @mobileNumber";
                    sqlCommand.Parameters.AddWithValue("@mobileNumber", student.MobileNumber);

                    mySqlDataReader = sqlCommand.ExecuteReader();

                    while (mySqlDataReader.Read())
                    {
                        validMobileNumber = mySqlDataReader["mobileNumber"].ToString();
                    }

                    if (validMobileNumber == student.MobileNumber)
                    {
                        response.IsSuceess = false;
                        response.IsValidMobileNumber = false;

                        return response;
                    }

                    mySqlDataReader.Close();
                    sqlCommand.Parameters.Clear();

                    sqlCommand.CommandText = "INSERT INTO student (firstName, lastName, address, mobileNumber, birthDay, createdDate) VALUES" +
                                            "(@firstName, @lastName, @address, @mobileNumber, @birthDay, @createdDate)";

                    sqlCommand.Parameters.AddWithValue("@firstName", student.FirstName);
                    sqlCommand.Parameters.AddWithValue("@lastName", student.LastName);
                    sqlCommand.Parameters.AddWithValue("@address", student.Address);
                    sqlCommand.Parameters.AddWithValue("@mobileNumber", student.MobileNumber);
                    sqlCommand.Parameters.AddWithValue("@birthDay", DateTime.Parse(student.BirthDay));
                    sqlCommand.Parameters.AddWithValue("@createdDate", DateTime.UtcNow);

                }


                sqlCommand.ExecuteScalar();

                response.IsSuceess = true;
                response.IsValidMobileNumber = true;

            }
            catch(Exception ex)
            {

            }
            finally
            {
                mySqlConnection.Close();
                sqlCommand.Dispose();
            }
           
            return response;
        }
        #endregion
    }

    public class StudentSaveResponse
    {
        public bool IsSuceess { get; set; }
        public bool IsValidMobileNumber { get; set; }
    }
}
