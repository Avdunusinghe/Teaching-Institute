using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeachingInstitute.Business;
using TeachingInstitute.Business.Interfaces;
using TeachingInstitute.Model;
using static TeachingInstitute.Business.StudentService;

namespace TeachingInstitute.WebApp
{
    public partial class StudentRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var id = Request.QueryString["id"] == null ?  0 : int.Parse(Request.QueryString["id"]);

            if (!Page.IsPostBack)
            {
                if (id > 0)
                {
                    FillStudentFormData(id);
                }
            }

        }

        protected void FillStudentFormData(int id)
        {
            IStudentService _studentService = new StudentService();
            var student = _studentService.FillStudentForm(id);

            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            txtMobileNumber.Text = student.MobileNumber;
            txtAddress.Text = student.Address;
            txtBirthDay.Text = student.BirthDay;

        }

        protected void SaveStudent(object sender, EventArgs e)
        {
            string validMobileNumber = string.Empty;
            string message = string.Empty;
            string script = string.Empty;
            string url = string.Empty;
          
            var student = new Student();
               
            student.Id = Request.QueryString["id"] == null ? 0 : int.Parse(Request.QueryString["id"]);
            student.FirstName = txtFirstName.Text.Trim();
            student.LastName = txtLastName.Text.Trim();
            student.MobileNumber = txtMobileNumber.Text.Trim();
            student.BirthDay = txtBirthDay.Text.Trim();
            student.Address = txtAddress.Text.Trim();

            IStudentService _studentService = new StudentService();
            var response = _studentService.SaveStudent(student);

            if (!response.IsValidMobileNumber)
            {
                message = "Mobile Number All Ready Exsist,Please Enter Your Mobile Number";
                script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
            }

            if (response.IsSuceess)
            {
               message = student.Id == 0 ? "Student Save Successsfull..." : "Student Update Successfull...";
               url = "StudentList.aspx";
               script = "window.onload = function(){ alert('";
               script += message;
               script += "');";
               script += "window.location = '";
               script += url;
               script += "'; }";
               ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
            }
        }
    }
}