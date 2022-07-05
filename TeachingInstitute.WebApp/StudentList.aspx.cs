using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeachingInstitute.Business;
using TeachingInstitute.Business.Interfaces;
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

        public void GetStudentDetails()
        {

            IStudentService _studentService = new StudentService();
            var students = _studentService.GetStudents();


            gridStudentList.DataSource = students;
            gridStudentList.DataBind();
        }

        protected void GridPageIndexChange(object sender, GridViewPageEventArgs e)
        {
            gridStudentList.PageIndex = e.NewPageIndex;
            this.GetStudentDetails();
        }


        protected void btn_delete_Click(object sender, EventArgs e)
        {
            var studentId = int.Parse((sender as Button).CommandArgument);

            IStudentService _studentService = new StudentService();
            var response = _studentService.DeleteStudent(studentId);

            if (response)
            {
                string message = "Student Delete Successfull...";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);


                this.GetStudentDetails();

            }

        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            var id = int.Parse((sender as Button).CommandArgument);

            Response.Redirect("StudentRegister.aspx?id=" + id);


        }
    }
}