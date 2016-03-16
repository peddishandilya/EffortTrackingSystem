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
    public partial class EmpWorkingHrs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllEmpTask();
            }
        }


        private void BindAllEmpTask()
        {
            try
            {
                DBHelper objHepler = new DBHelper("GetEmpTask_proc", true);
                objHepler.AddParameters("@UserId", Session["UserId"]);
                DataTable dtEmpTask = objHepler.ResultantTable;
                objHepler.FillDataTable();
                ddlAsgnTasks.DataSource = dtEmpTask;
                ddlAsgnTasks.DataValueField = "UserTaskId";
                ddlAsgnTasks.DataTextField = "TaskName";
                ddlAsgnTasks.DataBind();
                ddlAsgnTasks.Items.Insert(0, "--Select--");
                ddlAsgnTasks.SelectedIndex = 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DBHelper objConnection = new DBHelper("InsertUpdateUserTaskTime_proc", false);

            objConnection.OpenConnection();
            objConnection.AddParameters("@userTaskId", ddlAsgnTasks.SelectedValue);
            objConnection.AddParameters("@Date", txtDate.Text);
            objConnection.AddParameters("@Hrs", txtWorkingHrs.Text);
            int success = objConnection.ExecuteNonQuery();
            objConnection.CloseConnection();
        }

    }
}