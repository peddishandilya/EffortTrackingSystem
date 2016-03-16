using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using EffortTrackingSystem.Utilities;
using System.Drawing;


namespace EffortTrackingSystem
{
    public partial class ManageEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllDept();
                BindAllEmployee();
            }
        }

        private void BindAllEmployee()
        {
            try
            {
                DBHelper objHepler = new DBHelper("GetAllEmp_proc", true);
                DataTable dtAllEmp = objHepler.ResultantTable;
                objHepler.FillDataTable();
                ddlEmployee.DataSource = dtAllEmp;
                ddlEmployee.DataValueField = "UserId";
                ddlEmployee.DataTextField = "UserName";
                ddlEmployee.DataBind();
                ddlEmployee.Items.Insert(0, "--Select--");
                ddlEmployee.Items.Add(new ListItem("Create new", "new"));
                ddlEmployee.SelectedIndex = 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void BindAllDept()
        {
            try
            {
                DBHelper objHepler = new DBHelper("GetAllDept_proc", true);
                DataTable dtLeaveType = objHepler.ResultantTable;
                objHepler.FillDataTable();
                ddlDept.DataSource = dtLeaveType;
                ddlDept.DataValueField = "DeptId";
                ddlDept.DataTextField = "Dept";
                ddlDept.DataBind();
                ddlDept.Items.Insert(0, "--Select--");
                ddlDept.SelectedIndex = 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DBHelper objConnection = new DBHelper("InsertUpdateUser_proc", false);

            objConnection.OpenConnection();
            objConnection.AddParameters("@UserName", txtName.Text);
            objConnection.AddParameters("@EmailId", txtEmail.Text);
            objConnection.AddParameters("@PhoneNo", txtPhoneno.Text);
            objConnection.AddParameters("@RoleId", 2);
            objConnection.AddParameters("@DeptId", ddlDept.SelectedValue);
            objConnection.AddParameters("@Salary",txtSalary.Text);
            if (ddlEmployee.SelectedIndex > 0 && ddlEmployee.SelectedValue != "new")
            {
                objConnection.AddParameters("@UserId", ddlEmployee.SelectedValue);
            }

            int success = objConnection.ExecuteNonQuery();
            objConnection.CloseConnection();
        }

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlEmployee.SelectedIndex > 0 && ddlEmployee.SelectedValue != "new")
                {
                    DBHelper objHepler = new DBHelper("GetEmp_proc", true);
                    objHepler.AddParameters("@UserId", ddlEmployee.SelectedValue);
                    DataTable dtEmp = objHepler.ResultantTable;
                    objHepler.FillDataTable();

                    txtName.Text = dtEmp.Rows[0]["UserName"].ToString();
                    txtPhoneno.Text = dtEmp.Rows[0]["PhoneNo"].ToString();
                    txtEmail.Text = dtEmp.Rows[0]["EmailId"].ToString();
                    ddlDept.SelectedValue = dtEmp.Rows[0]["DeptId"].ToString();
                  txtSalary.Text = dtEmp.Rows[0]["Salary"].ToString();

                }
                else if (ddlEmployee.SelectedValue == "new")
                {
                    txtName.Text = string.Empty;
                    txtPhoneno.Text = string.Empty;
                    ddlDept.SelectedIndex = 0;
                    txtEmail.Text = string.Empty;
                    txtSalary.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Object reference"))
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    //  lblmessage.Text = "There was an error, please try again";
                    // lblmessage.ForeColor = Color.Red;
                }
            }
        }
    }
}