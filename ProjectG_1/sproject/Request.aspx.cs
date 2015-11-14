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
    public partial class Request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["loginName"].ToString();

            if (!IsPostBack)
            {
                string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();

                SqlCommand cmd = new SqlCommand(" SELECT project.PID, project.PNameTH, CPE01.FormNo, CPE01.status, CPE01.date FROM CPE01 INNER JOIN project ON CPE01.PID = project.PID WHERE ((project.advisorID = '" + Session["loginSID"] + "') OR (project.coAdvisorID = '" + Session["loginSID"] + "')) and CPE01.status='wait' "
                                                    + "UNION SELECT project.PID, project.PNameTH, CPE02.FormNo, CPE02.status, CPE02.date FROM CPE02 INNER JOIN project ON CPE02.PID = project.PID WHERE ((project.advisorID = '" + Session["loginSID"] + "') OR (project.coAdvisorID = '" + Session["loginSID"] + "')) and CPE02.status='wait' "
                                                    + "UNION SELECT project.PID, project.PNameTH, CPE03.FormNo, CPE03.status, CPE03.date FROM CPE03 INNER JOIN project ON CPE03.PID = project.PID WHERE ((project.advisorID = '" + Session["loginSID"] + "') OR (project.coAdvisorID = '" + Session["loginSID"] + "')) and CPE03.status='wait' "
                                                    + "UNION SELECT project.PID, project.PNameTH, CPE04.FormNo, CPE04.status, CPE04.date FROM CPE04 INNER JOIN project ON CPE04.PID = project.PID WHERE ((project.advisorID = '" + Session["loginSID"] + "') OR (project.coAdvisorID = '" + Session["loginSID"] + "')) and CPE04.status='wait' "
                                                    + "UNION SELECT project.PID, project.PNameTH, CPE05.FormNo, CPE05.status, CPE05.date FROM CPE05 INNER JOIN project ON CPE05.PID = project.PID WHERE ((project.advisorID = '" + Session["loginSID"] + "') OR (project.coAdvisorID = '" + Session["loginSID"] + "')) and CPE05.status='wait' "
                                                    + "ORDER BY date DESC ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                con.Close();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeTeacher.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Request.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string value = DropDownList1.SelectedValue.ToString();
            if (value == "0")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(" SELECT project.PID, project.PNameTH, CPE01.FormNo, CPE01.status, CPE01.date FROM CPE01 INNER JOIN project ON CPE01.PID = project.PID WHERE ((project.advisorID = '"+Session["loginSID"]+"') OR (project.coAdvisorID = '"+Session["loginSID"]+"')) and CPE01.status='wait' "
                                                    + "UNION SELECT project.PID, project.PNameTH, CPE02.FormNo, CPE02.status, CPE02.date FROM CPE02 INNER JOIN project ON CPE02.PID = project.PID WHERE ((project.advisorID = '" + Session["loginSID"] + "') OR (project.coAdvisorID = '" + Session["loginSID"] + "')) and CPE02.status='wait' "
                                                    + "UNION SELECT project.PID, project.PNameTH, CPE03.FormNo, CPE03.status, CPE03.date FROM CPE03 INNER JOIN project ON CPE03.PID = project.PID WHERE ((project.advisorID = '" + Session["loginSID"] + "') OR (project.coAdvisorID = '" + Session["loginSID"] + "')) and CPE03.status='wait' "
                                                    + "UNION SELECT project.PID, project.PNameTH, CPE04.FormNo, CPE04.status, CPE04.date FROM CPE04 INNER JOIN project ON CPE04.PID = project.PID WHERE ((project.advisorID = '" + Session["loginSID"] + "') OR (project.coAdvisorID = '" + Session["loginSID"] + "')) and CPE04.status='wait' "
                                                    + "UNION SELECT project.PID, project.PNameTH, CPE05.FormNo, CPE05.status, CPE05.date FROM CPE05 INNER JOIN project ON CPE05.PID = project.PID WHERE ((project.advisorID = '" + Session["loginSID"] + "') OR (project.coAdvisorID = '" + Session["loginSID"] + "')) and CPE05.status='wait' "
                                                    + "ORDER BY date DESC ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                con.Close();
            }
            else if (value == "1")
            {
                
                string whatCommit = "";
                con.Open();
                string logID = Session["loginSID"].ToString();
                SqlCommand cmd = new SqlCommand("SELECT * FROM project WHERE (committee1ID = '" + Session["loginSID"].ToString() + "') OR (committee2ID = '" + Session["loginSID"].ToString() + "') OR (committee3ID = '" + Session["loginSID"].ToString() + "') ", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (logID == reader["committee1ID"].ToString())
                    {
                        Session["whatCommittee"] = "1";
                        whatCommit = Session["whatCommittee"].ToString();
                    }
                    else if (logID == reader["committee2ID"].ToString())
                    {
                        Session["whatCommittee"] = "2";
                        whatCommit = Session["whatCommittee"].ToString();
                    }
                    else if (logID == reader["committee3ID"].ToString())
                    {
                        Session["whatCommittee"] = "3";
                        whatCommit = Session["whatCommittee"].ToString();
                    }
                }

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('" + whatCommit + "');", true);

                con.Close();

                if (whatCommit == "1")
                {

                    con.Open();

                    SqlCommand cmd2 = new SqlCommand(" SELECT project.PID, project.PNameTH, CPE03.FormNo, CPE03.status, CPE03.date FROM CPE03 INNER JOIN project ON CPE03.PID = project.PID WHERE (project.committee1ID = '" + Session["loginSID"] + "' AND CPE03.c1 = '0') AND CPE03.status='wait' ORDER BY date DESC ", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    con.Close();
                }
                else if (whatCommit == "2")
                {

                    con.Open();

                    SqlCommand cmd2 = new SqlCommand(" SELECT project.PID, project.PNameTH, CPE03.FormNo, CPE03.status, CPE03.date FROM CPE03 INNER JOIN project ON CPE03.PID = project.PID WHERE (project.committee2ID = '" + Session["loginSID"] + "' AND CPE03.c2 = '0') AND CPE03.status='wait' ORDER BY date DESC ", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    con.Close();
                }
                else if (whatCommit == "3")
                {

                    con.Open();

                    SqlCommand cmd2 = new SqlCommand(" SELECT project.PID, project.PNameTH, CPE03.FormNo, CPE03.status, CPE03.date FROM CPE03 INNER JOIN project ON CPE03.PID = project.PID WHERE (project.committee3ID = '" + Session["loginSID"] + "' AND CPE03.c3 = '0') AND CPE03.status='wait' ORDER BY date DESC ", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    con.Close();
                }
            }
        }
    }
}