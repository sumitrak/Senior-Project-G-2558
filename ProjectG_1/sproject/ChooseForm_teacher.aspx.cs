using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sproject
{
    public partial class ChooseForm_teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["loginName"].ToString();
            string whatPID = Request.QueryString["PID"];
            Session["whatPID"] = whatPID;
            string whatForm = Request.QueryString["FormNo"];
            if (whatForm == "1")
            {
                Response.Redirect("CPE01_teacher.aspx");
            }
            else if(whatForm == "2")
            {
                Response.Redirect("CPE02_teacher.aspx");
            }
            else if (whatForm == "3")
            {
                Response.Redirect("CPE03_teacher.aspx");
            }
            else if (whatForm == "4")
            {
                Response.Redirect("CPE04_teacher.aspx");
            }
            else if (whatForm == "5")
            {
                Response.Redirect("CPE05_teacher.aspx");
            }
            else
            {
                Response.Redirect("construct.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeTeacher.aspx");
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void okBtn_Click(object sender, EventArgs e)
        {
            /*
            string value = DropDownList1.SelectedValue.ToString();
            if (value == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('กรุณาเลือกแบบฟอร์ม');", true);
            }
            else if (value == "1")
            {
                Response.Redirect("CPE01_teacher.aspx");
            }
            else
            {
                Response.Redirect("construct.aspx");
            }
            */
        }
    }
}