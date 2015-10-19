using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Web.Configuration;


namespace sproject
{

    

    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();

            Session["Date"] = DateTime.Now;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM username where username = '" + IDBox.Text + "' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            string compare_password = "";
            string type = "";

            while (reader.Read())
            {
                compare_password = reader["password"].ToString();
                type = reader["type"].ToString();
            }
            con.Close();
            

            if (IDBox.Text != "" && PWBox.Text != "")
            {
                if (compare_password == PWBox.Text)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('OK');", true);
                    
                    if (type == "teacher")
                    {
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("SELECT username.username, teacher.TName FROM username JOIN teacher ON username.username=teacher.username WHERE username.username = '" + IDBox.Text + "' ", con);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        string LoginName = "";
                        string LoginSID = "";

                        while (reader2.Read())
                        {
                            LoginName = reader2["TName"].ToString();
                            LoginSID = reader2["username"].ToString();
                        }

                        Session["loginName"] = LoginName;
                        Session["loginSID"] = LoginSID;
                        Response.Redirect("HomeTeacher.aspx");
                        reader2.Close();
                        con.Close();
                    }
                    
                    if (type == "student")
                    {
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("SELECT username.username, student.SName FROM username JOIN student ON username.username=student.SID WHERE username= '" + IDBox.Text + "' ", con);
                        SqlDataReader reader3 = cmd2.ExecuteReader();
                        string LoginName = "";
                        string LoginSID = "";

                        while (reader3.Read())
                        {
                            LoginName = reader3["SName"].ToString();
                            LoginSID = reader3["username"].ToString();
                        }

                        Session["loginName"] = LoginName;
                        Session["loginSID"] = LoginSID;
                        Response.Redirect("HomeStudent.aspx");
                        reader3.Close();
                        con.Close();
                    }
                    
                }
                else checkLogin.Text = "ID or Password is not correct";
            }
            else checkLogin.Text = "Please insert ID and Password";
            
        }
        
        protected void Button2_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('Under construction');", true);
            Response.Redirect("construct.aspx");
        }


    }
}