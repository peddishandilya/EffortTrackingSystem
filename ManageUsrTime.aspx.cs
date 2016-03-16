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
    public partial class ManageUsrTime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllDept();
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

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDept.SelectedIndex > 0)
            {
                try
                {
                    DBHelper objHepler = new DBHelper("GetDeptTask_proc", true);
                    objHepler.AddParameters("@DeptId", ddlDept.SelectedValue);
                    DataTable dtDeptTask = objHepler.ResultantTable;
                    objHepler.FillDataTable();
                    ddlTask.DataSource = dtDeptTask;
                    ddlTask.DataValueField = "TaskId";
                    ddlTask.DataTextField = "TaskName";
                    ddlTask.DataBind();
                    ddlTask.Items.Insert(0, "--Select--");
                    ddlTask.SelectedIndex = 0;
                   


                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
          
        }
        protected void logindetails()
        {
            DBHelper objHepler = new DBHelper("GetEmpLoginDetails_proc", true);
            objHepler.AddParameters("@UserId", Session["UserId"]);
            objHepler.AddParameters("@Dept", ddlDept.SelectedItem.ToString());
            objHepler.AddParameters("@date", txtDate.Text);
            DataTable dtEmpTask = objHepler.ResultantTable;
            objHepler.FillDataTable();
            emplogin.DataSource = dtEmpTask;
            emplogin.DataBind();
           

        }


        private void BindGrid()
        {
            DBHelper objHepler = new DBHelper("GetEmpPendingTime", true);
            objHepler.AddParameters("@Date", txtDate.Text);
            objHepler.AddParameters("@TaskId", ddlTask.SelectedValue);
            DataTable dtEmpTask = objHepler.ResultantTable;
            objHepler.FillDataTable();
            gvEmpPendingTime.DataSource = dtEmpTask;
            gvEmpPendingTime.DataBind();
        }

        protected void gvEmpPendingTime_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmpPendingTime.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvEmpPendingTime_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEmpPendingTime.EditIndex = -1;
            BindGrid();
        }

        protected void gvEmpPendingTime_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)gvEmpPendingTime.Rows[e.RowIndex];
            Label lblTaskTimeId = (Label)gvr.FindControl("lblTaskTimeId");
            int TaskTimeId = Convert.ToInt32(lblTaskTimeId.Text);
            TextBox txtWHrs = (TextBox)gvr.FindControl("txtWorkingHours");
            double wHrs = Convert.ToDouble(txtWHrs.Text);

            DropDownList ddlStat = (DropDownList)gvr.FindControl("ddlStatus");
            string status = ddlStat.SelectedItem.ToString();

           
              //  int i = objinvBal.UpdateInventionStatus(InventionId, id);

            DBHelper objConnection = new DBHelper("InsertUpdateUserTaskTime_proc", false);

            objConnection.OpenConnection();
            objConnection.AddParameters("@TaskTimeId", TaskTimeId);
            objConnection.AddParameters("@Status", status);
            objConnection.AddParameters("@Hrs", wHrs);
            int success = objConnection.ExecuteNonQuery();
            objConnection.CloseConnection();        
            gvEmpPendingTime.EditIndex = -1;
            BindGrid();
        }

        protected void gvEmpPendingTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindGrid();
            logindetails();
        }
    }
}