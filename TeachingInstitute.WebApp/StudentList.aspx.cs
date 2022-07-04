using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeachingInstitute.Model;

namespace TeachingInstitute.WebApp
{
    public partial class StudentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.GetStudentDetails();
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public void GetStudentDetails()
        {
            var studentList = new List<Student>();

            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["TIConnection"].ToString();
                var mySqlConnection = new MySqlConnection(connectionString);
                MySqlCommand sqlCommand = new MySqlCommand("", mySqlConnection);
                MySqlDataReader mySqlDataReader = null;
                mySqlConnection.Open();

             

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

                gridStudentList.DataSource = studentList;
                gridStudentList.DataBind();

                mySqlDataReader.Close();
                mySqlConnection.Close();


            }
            catch (Exception ex)
            {

            }


           
        }

        protected void GridPageIndexChange(object sender, GridViewPageEventArgs e)
        {
            gridStudentList.PageIndex = e.NewPageIndex;
            this.GetStudentDetails();
        }

        protected void gridStudentList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gridStudentList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["TIConnection"].ToString();
                var mySqlConnection = new MySqlConnection(connectionString);
                MySqlCommand sqlCommand = new MySqlCommand("", mySqlConnection);
                mySqlConnection.Open();

                var studentId = gridStudentList.DataKeys[e.RowIndex].Value.ToString();

                sqlCommand.CommandText = "DELETE from student WHERE id = @studentId";

                sqlCommand.Parameters.AddWithValue("@studentId", int.Parse(studentId));

                sqlCommand.ExecuteScalar();
                mySqlConnection.Close();


                this.GetStudentDetails();
            }
            catch(Exception ex)
            {

            }
           

           



        }

        protected void gridStudentList_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}