﻿using MySql.Data.MySqlClient;
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
            var studentList = new List<Student>();
            studentList = GetStudentDetails();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public List<Student> GetStudentDetails()
        {
            var studentList = new List<Student>();

            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["TIConnection"].ToString();
                var mySqlConnection = new MySqlConnection(connectionString);
                MySqlCommand sqlCommand = new MySqlCommand("", mySqlConnection);
                MySqlDataReader mySqlDataReader = null;
                mySqlConnection.Open();

                sqlCommand.CommandText = "SELECT id, firstName, lastName, address, mobileNumber, birthday FROM student";
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
                        BirthDay = mySqlDataReader["birthDay"].ToString()
                    };

                    studentList.Add(studentDetails);
                }

                mySqlDataReader.Close();
                mySqlConnection.Close();


            }
            catch (Exception ex)
            {

            }


            return studentList;
        }
    }
}