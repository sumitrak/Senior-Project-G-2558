using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sproject
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {/*
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();



            con.Close();*/
            Session["aPID"] = "teacher1";
            /*
            SessionParameter aPID = new SessionParameter();
            aPID.Name = "aPID";
            aPID.Type = TypeCode.String;
            aPID.SessionField = "aPID";
            */
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["ppp"] = "teacher1";
        }
    }
}