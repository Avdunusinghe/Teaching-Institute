using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeachingInstitute.Model;

namespace TeachingInstitute.WebApp
{
    public partial class StudentRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveStudent(object sender, EventArgs e)
        {
            try
            {
                var student = new Student();

                var connectionString = ConfigurationManager.ConnectionStrings["TIConnection"].ToString();
                var mySqlConnection = new MySqlConnection(connectionString);
                MySqlCommand sqlCommand = new MySqlCommand("", mySqlConnection);
                mySqlConnection.Open();


                student.FirstName = txtFirstName.Text.Trim();
                student.LastName = txtLastName.Text.Trim();
                student.MobileNumber = txtMobileNumber.Text.Trim();
                student.BirthDay = txtBirthDay.Text.Trim();
                student.Address = txtAddress.Text.Trim();

                sqlCommand.CommandText = "INSERT INTO student (firstName, lastName, address, mobileNumber, birthDay, createdDate) VALUES" +
                    "(@firstName, @lastName, @address, @mobileNumber, @birthDay, @createdDate)";

                sqlCommand.Parameters.AddWithValue("@firstName", student.FirstName);
                sqlCommand.Parameters.AddWithValue("@lastName", student.LastName);
                sqlCommand.Parameters.AddWithValue("@address", student.Address);
                sqlCommand.Parameters.AddWithValue("@mobileNumber", student.MobileNumber);
                sqlCommand.Parameters.AddWithValue("@birthDay", DateTime.Parse(student.BirthDay));
                sqlCommand.Parameters.AddWithValue("@createdDate", DateTime.UtcNow);

                sqlCommand.ExecuteScalar();
                mySqlConnection.Close();

              
                Response.Redirect("StudentList.aspx");

            }
            catch(Exception ex)
            {

            }
          

            
        }
    }
}