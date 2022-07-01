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
    public partial class StudentRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveStudent(object sender, EventArgs e)
        {
            var student = new Student();

            var connectionString = ConfigurationManager.ConnectionStrings["TIConnection"].ToString();

            var mySqlConnection = new MySqlConnection(connectionString);

            mySqlConnection.Open();



            
        }
    }
}