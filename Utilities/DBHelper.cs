using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EffortTrackingSystem.Utilities
{
    public class DBHelper
    {
        #region variables

        SqlCommand Command = null;
        SqlConnection DBConnection = null;
        SqlDataAdapter DataAdapter = null;
        public DataTable ResultantTable = null;
        public SqlDataReader DataReader = null;

        #endregion
        public DBHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DBHelper(string StoreProcedureName, bool ExecuteType = false)
        {
            DBConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ETSConnectionString"].ConnectionString);
            Command = new SqlCommand(StoreProcedureName, DBConnection);
            Command.CommandType = CommandType.StoredProcedure;
            if (ExecuteType == true)
            {
                ResultantTable = new DataTable();
                DataAdapter = new SqlDataAdapter(Command);
            }
        }

        /// <summary>
        /// Opens the Connection.
        /// </summary>
        public void OpenConnection()
        {
            DBConnection.Open();
        }

        /// <summary>
        /// Close the Connection.
        /// </summary>
        public void CloseConnection()
        {
            DBConnection.Close();
        }

        /// <summary>
        /// Adds the Parameters to the Command Object Required for the execution.
        /// </summary>
        /// <param name="ParameterName">Name of the parameter with Prefix @ </param>
        /// <param name="Value">Value of the Parameter </param>
        public void AddParameters(String ParameterName, object Value)
        {
            if (Command != null)
            {
                Command.Parameters.AddWithValue(ParameterName, Value);
            }
            else
            {
                throw new ApplicationException("Sql Command is being used without initialization");
            }
        }


        public void RemoveParameters()
        {
            if (Command != null)
            {
                Command.Parameters.Clear();
            }
        }

        /// <summary>
        /// Executes Non Query
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuery()
        {
            if (DBConnection.State == ConnectionState.Open)
            {
                return Command.ExecuteNonQuery();
            }
            else
            {
                throw new ApplicationException("Connnection Not Opened");
            }
        }

        /// <summary>
        ///  
        /// </summary>
        public void FillDataTable()
        {
            if (DataAdapter != null)
            {
                DataAdapter.Fill(ResultantTable);
            }
            else
            {
                throw new ApplicationException("Data Adapter is being used without initialization");
            }
        }

        /// <summary>
        /// Executes the Reader Operation
        /// </summary>
        public void ExecuteReader()
        {
            if (DBConnection.State != ConnectionState.Open)
            {
                throw new ApplicationException("Connnection Not Opened");
            }

            if (Command != null)
            {
                DataReader = Command.ExecuteReader();
            }
            else
            {
                throw new ApplicationException("Sql Command is being used without initialization");
            }
        }
    }
}