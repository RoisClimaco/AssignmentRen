using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyProjectSite1
{
    /* Reviewed By: ROLANDO
     * Curly brackets are on the next line; it should be on the same line as the condition / method names
     * Comments should be placed for complicated codes
     **/
    public class DataAccessLayer
    {
        private string sErrorMsg = "";
        public DataAccessLayer()
        {
            sErrorMsg = "";
        }

        public string ErrorMessage
        {
            get
            {
                return sErrorMsg;
            }
        }

        public int AddUser( string emailID, string password,  string contactNo,
                  string userName, string gender)
        {
            sErrorMsg = "";
            int iID = 0;
            SqlConnection connection = null;
            try
            {
                connection = getConnection();
                //check if exists

                if (connection.State == ConnectionState.Open)
                {
                    if (CheckUserExists(connection, emailID) == 0)
                    {
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter("sp_adduserdetail", connection);
                        sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlAdapter.SelectCommand.Parameters.AddWithValue("@userEmailID", emailID);
                        sqlAdapter.SelectCommand.Parameters.AddWithValue("@userPassword", password);
                        sqlAdapter.SelectCommand.Parameters.AddWithValue("@userName", userName);
                        sqlAdapter.SelectCommand.Parameters.AddWithValue("@contactNo", contactNo);
                        sqlAdapter.SelectCommand.Parameters.AddWithValue("@gender", gender);
                        DataTable dt = new DataTable();
                        sqlAdapter.Fill(dt);
                        sqlAdapter.Dispose();
                        sqlAdapter = null;
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["statusID"].ToString().Trim() == "1")
                                iID = int.Parse(dt.Rows[0]["userID"].ToString().Trim());
                            else
                                sErrorMsg = dt.Rows[0]["statusMessage"].ToString().Trim();
                        }
                    }
                    else
                    {
                        sErrorMsg = "User already exists.";
                    }
                }
                else
                {
                    Console.Write("Unable to establish database connection");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    if (connection.State != System.Data.ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }

            return iID;
        }

        private int CheckUserExists(SqlConnection connection, string emailID)
        {
            
            int userID = 0;
           
            SqlCommand sqlCommand = new SqlCommand("select userID from tbUsers where userEmailID=@id", connection);
            sqlCommand.Parameters.AddWithValue("@id", emailID);

          
            SqlDataReader reader = sqlCommand.ExecuteReader();
          
            if (reader.HasRows)
            {
                reader.Read();
                userID = int.Parse(reader["userID"].ToString().Trim());
                reader.Close();
            }
            sqlCommand.Dispose();
            reader.Close();
            reader = null;
            return userID;
        }

        private SqlConnection getConnection()
        {

            SqlConnection connection = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyProjectSite1.Properties.Settings.dbConnectionString"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (SqlException ex)
            {

            }
            return connection;
        }
    }
}