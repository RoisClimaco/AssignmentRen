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
     * Commented codes should be removed
     * Not following a 3-tier approach, there should be a middle class between UI and Database Connector
     * Select * should not be used when accessing the database
     **/
    public class UserInfo
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string emailID { get; set; }
        public string contactNo { get; set; }

        public string password { get; set; }
        public string gender { get; set; }
    }
        public class LoginData
    {
        private string sErrorMsg = "";
        public LoginData()
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

        public UserInfo GetUserInfo(string emailID = "", string password = "")
        {
            sErrorMsg = "";
            SqlConnection connection = null;
            int iID = 0;
            UserInfo userInfo = null;
            try
            {
                connection = getConnection();
                //check if exists

                if (connection.State == ConnectionState.Open)
                {
                    string sQuery = "select * from tbUsers where ";
                    SqlParameter[] paramColl;
                    //if (userID > 0)
                    //{
                    //    sQuery += " userID = @id ";
                    //    paramColl = new SqlParameter[1];
                    //    paramColl[0] = new SqlParameter("@id", userID);
                    //}
                    //else
                     if (emailID.Trim() != "" && password.Trim() == "")
                    {
                        sQuery += "userEmailID=@email";

                        paramColl = new SqlParameter[1];
                        paramColl[0] = new SqlParameter("@email", emailID);

                    }
                    else
                    {
                        sQuery += "userEmailID=@email and userPassword=@pwd";

                        paramColl = new SqlParameter[2];
                        paramColl[0] = new SqlParameter("@email", emailID);
                        paramColl[1] = new SqlParameter("@pwd", password);
                    }
                    SqlCommand sqlCommand = new SqlCommand(sQuery, connection);
                    sqlCommand.Parameters.AddRange(paramColl);
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    sqlCommand.Dispose();
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        iID = int.Parse(dataReader["userID"].ToString().Trim());
                        userInfo = new UserInfo();
                        userInfo.userID = iID;
                        userInfo.emailID = dataReader["userEmailID"].ToString().Trim();
                        userInfo.userName = dataReader["userName"].ToString().Trim();
                        userInfo.contactNo = dataReader["contactNo"].ToString().Trim();
                        userInfo.password = dataReader["userPassword"].ToString().Trim();
                        userInfo.gender = dataReader["gender"].ToString().Trim();
                    }
                    else
                    {
                        sErrorMsg = "Invalid email ID and/or password.";
                    }
                    sqlCommand.Dispose();
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

            return userInfo;
        }
    }
}