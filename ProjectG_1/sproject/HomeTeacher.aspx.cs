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
    public partial class HomeTeacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["loginName"].ToString();
            string ID = Session["loginSID"].ToString();
            Session["tStatus"] = DropDownList1.SelectedValue.ToString();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('" + Session["tStatus"].ToString() + "');", true); 
            if(!IsPostBack)
            {
                bindGridView();
                if (ID == "teacher1")
                {
                    DropDownList1.Items.Insert(3, new ListItem("ผู้ดูแลระบบ", "3"));
                }
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeTeacher.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Request.aspx");
        }

        private void bindGridView()
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT PID, PNameTH, PNameENG FROM project WHERE (advisorID = '" + Session["loginSID"].ToString() + "') ", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            con.Close();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string value = DropDownList1.SelectedValue.ToString();
            if (value == "0")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT PID, PNameTH, PNameENG FROM project WHERE (advisorID = '" + Session["loginSID"].ToString() + "') ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                con.Close();
            }
            else if (value == "1")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT PID, PNameTH, PNameENG FROM project WHERE (coAdvisorID = '" + Session["loginSID"].ToString() + "') ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                con.Close();
            }
            else if (value == "2")
            {
                //con.Open();
                //string logID = Session["loginSID"].ToString();
                //SqlCommand cmd = new SqlCommand("SELECT * FROM project WHERE (committee1ID = '" + Session["loginSID"].ToString() + "') OR (committee2ID = '" + Session["loginSID"].ToString() + "') OR (committee3ID = '" + Session["loginSID"].ToString() + "') ", con);
                //SqlDataReader reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                //    if (logID == reader["committee1ID"].ToString())
                //    {
                //        Session["whatCommittee"] = "1";
                //    }
                //    else if (logID == reader["committee2ID"].ToString())
                //    {
                //        Session["whatCommittee"] = "2";
                //    }
                //    else if (logID == reader["committee3ID"].ToString())
                //    {
                //        Session["whatCommittee"] = "3";
                //    }
                //}
                //con.Close();

                /////////////////////////////////////////////////////////////
                con.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT PID, PNameTH, PNameENG FROM project WHERE (committee1ID = '" + Session["loginSID"].ToString() + "') OR (committee2ID = '" + Session["loginSID"].ToString() + "') OR (committee3ID = '" + Session["loginSID"].ToString() + "') ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                con.Close();

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('" + Session["whatCommittee"].ToString() + "');", true); 
            }
            else if (value == "3")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT PID, PNameTH, PNameENG FROM project ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                con.Close();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindGridView();
        }
    }
}