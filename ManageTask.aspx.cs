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
    public partial class ManageTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllDept();
                BindAllTask();

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
    
        
        private void BindAllTask()
        {
            try
            {
                DBHelper objHepler = new DBHelper("GetAllTask_proc", true);
                DataTable dtTasks = objHepler.ResultantTable;
                objHepler.FillDataTable();
                ddlTask.DataSource = dtTasks;
                ddlTask.DataValueField = "TaskId";
                ddlTask.DataTextField = "TaskName";
                ddlTask.DataBind();
                ddlTask.Items.Insert(0, "--Select--");
                ddlTask.Items.Add(new ListItem("Create new", "new"));
                ddlTask.SelectedIndex = 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTask.SelectedIndex > 0 && ddlTask.SelectedValue != "new")
            {
                DBHelper objHepler = new DBHelper("GetTask_proc", true);
                objHepler.AddParameters("@TaskId", ddlTask.SelectedValue);
           
                DataTable dtTask = objHepler.ResultantTable;
                objHepler.FillDataTable();
                txtTaskName.Text = dtTask.Rows[0]["TaskName"].ToString();
                ddlStatus.Text = dtTask.Rows[0]["IsActive"].ToString();
                ddlDept.SelectedValue = dtTask.Rows[0]["DeptId"].ToString();
                txtTaskName.Enabled = true;
              
            } else if (ddlTask.SelectedValue == "new")
                {
                    txtTaskName.Text = string.Empty;
                 
                 //   ddlDept.SelectedIndex = 0;
                   

                }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ddlDept.SelectedIndex > 0 && ddlTask.SelectedIndex > 0)
            {
                DBHelper objConnection = new DBHelper("InsertUpdateTask_proc", false);

                objConnection.OpenConnection();
                objConnection.AddParameters("@TaskName", txtTaskName.Text);
                objConnection.AddParameters("@DeptId", ddlDept.SelectedValue);
                objConnection.AddParameters("@IsActive", ddlStatus.SelectedValue);
      

                if (ddlTask.SelectedValue != "new")
                {
                    objConnection.AddParameters("@TaskId", ddlTask.SelectedValue);
                }

                int success = objConnection.ExecuteNonQuery();
                objConnection.CloseConnection();
            }
        }
    }
}