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
    public partial class ViewPayroll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
             DBHelper objConnection = new DBHelper("GetEmpSalary", false);
             string sal="0";

                objConnection.OpenConnection();
                objConnection.AddParameters("@Month", ddlMonth.SelectedValue);
                objConnection.AddParameters("@UserId",Session["UserId"].ToString() );
                objConnection.ExecuteReader();
                SqlDataReader dr = objConnection.DataReader;
                if (dr.Read())
                {

                    sal = dr[0].ToString();
                }

                lblSalDisplay.Text = "Your " + ddlMonth.SelectedItem.ToString() + " month salary is Rs" + sal;
                ModalPopupExtender1.Show();
        }
    }
}