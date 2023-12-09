using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// mở các thư viện
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DrugStoreManagement
{
    class DataServices
    {
        private static SqlConnection mySqlConnection;
        private SqlDataAdapter mySqlDataAdapter;

        // kết nối đến DB
        public bool OpenDB()
        {
            string conStr = "Data Source=LAPTOP-VHVPC4RM\\SQLEXPRESS;Initial Catalog=Mart;Integrated Security=True";
            try
            {
                mySqlConnection = new SqlConnection(conStr);
                mySqlConnection.Open();
            }
            catch (SqlException ex)
            {
                DisplayError(ex);
                mySqlConnection = null;
                return false;
            }
            return true;
        }

        //
        // 
        public DataTable RunQuery(string query, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(query, mySqlConnection);
                cmd.Parameters.AddRange(parameters);
                mySqlDataAdapter = new SqlDataAdapter(cmd);
                SqlCommandBuilder mySqlCommandBuilder = new SqlCommandBuilder(mySqlDataAdapter);
                mySqlDataAdapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                DisplayError(ex);
                return null;
            }
            return dt;
        }

        // Update a DataTable to a database table
        public void Update(DataTable dt)
        {
            try
            {
                mySqlDataAdapter.Update(dt);
            }
            catch (SqlException ex)
            {
                DisplayError(ex);
            }
        }

        // Execute a SQL statement such as insert, update and delete
        public void ExecuteNonQuery(string sSql, params SqlParameter[] parameters)
        {
            SqlCommand mySqlCommand = new SqlCommand(sSql, mySqlConnection);
            mySqlCommand.Parameters.AddRange(parameters);
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                DisplayError(ex);
            }
        }

        public void DisplayError(SqlException ex)
        {
            string sSql = "SELECT * FROM Errors WHERE Number = @Number";
            DataTable dtError = RunQuery(sSql, new SqlParameter("@Number", ex.Number));
            if (dtError.Rows.Count > 0)
                MessageBox.Show(dtError.Rows[0][1].ToString().Trim(), "Error " + ex.Number.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(ex.Message, "Error " + ex.Number.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal int ExecuteScalar(string ordersSql, object ordersParameters)
        {
            throw new NotImplementedException();
        }
    }

}
