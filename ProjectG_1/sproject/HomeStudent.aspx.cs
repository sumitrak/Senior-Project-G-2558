using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sproject
{
    public partial class HomeStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            Label1.Text = Session["loginName"].ToString();
            if (!IsPostBack)
            {      
                fillTable();
            }
        }

        private void fillTable()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string whatPID = "";
            SqlCommand cmd = new SqlCommand("SELECT PID FROM student WHERE SID= '" + Session["loginSID"].ToString() + "' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            { 
                whatPID = reader["PID"].ToString();
                Session["sesPID"] = whatPID;
                if(whatPID == "")
                {
                    Button1.Visible = false;
                    Button2.Visible = false;
                }
            }

            con.Close();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeStudent.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChooseForm.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {

                con.Open();
                string whatPID = "";
                SqlCommand cmd = new SqlCommand("SELECT PID FROM student WHERE SID= '" + Session["loginSID"].ToString() + "' ", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                { whatPID = reader["PID"].ToString(); }
                con.Close();

                con.Open();

                SqlDataAdapter dtAd;
                DataTable dt = new DataTable();
                int rowCount;

                dtAd = new SqlDataAdapter("SELECT s.SID,s.SName,s.STel,s.SEmail, p.* FROM student s JOIN project p on s.PID=p.PID WHERE p.PID=" + whatPID + " ", con);
                dtAd.Fill(dt);
                rowCount = dt.Rows.Count;
                con.Close();
                if (rowCount == 1)
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("UPDATE student SET PID=null WHERE SID='" + Session["loginSID"].ToString() + "' ", con);
                    cmd2.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd3 = new SqlCommand(" DELETE FROM CPE01 WHERE PID = '"+whatPID+"' ", con);
                    cmd3.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd4 = new SqlCommand(" DELETE FROM project WHERE PID = '" + whatPID + "' ", con);
                    cmd4.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd5 = new SqlCommand(" DELETE FROM history WHERE PID = '" + whatPID + "' ", con);
                    cmd5.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd6 = new SqlCommand(" DELETE FROM CPE02 WHERE PID = '" + whatPID + "' ", con);
                    cmd6.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd7 = new SqlCommand(" DELETE FROM CPE02_data WHERE PID = '" + whatPID + "' ", con);
                    cmd7.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd8 = new SqlCommand(" DELETE FROM CPE03 WHERE PID = '" + whatPID + "' ", con);
                    cmd8.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd9 = new SqlCommand(" DELETE FROM CPE04 WHERE PID = '" + whatPID + "' ", con);
                    cmd9.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd10 = new SqlCommand(" DELETE FROM CPE05 WHERE PID = '" + whatPID + "' ", con);
                    cmd10.ExecuteNonQuery();
                    con.Close();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('ออกจากกลุ่มแล้ว');", true);
                }
                else
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("UPDATE student SET PID=null WHERE SID='" + Session["loginSID"].ToString() + "' ", con);
                    cmd2.ExecuteNonQuery();
                    con.Close();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('ออกจากกลุ่มแล้ว');", true);
                }

            }
            else
            {
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }
            Response.Redirect("HomeStudent.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("sHistory.aspx");
        }
    }
}