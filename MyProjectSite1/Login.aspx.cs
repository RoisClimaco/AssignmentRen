using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyProjectSite1
{
    /* Reviewed By: ROLANDO
     * Curly brackets are on the next line; it should be on the same line as the condition / method names
     * Commented code should be removed
     **/
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                LoginData dataLayer = new LoginData();
                UserInfo userInfo = dataLayer.GetUserInfo(txtEmailID.Text.Trim(), txtPassword.Text.Trim());
                if (userInfo != null)
                {
                    HttpCookie aCookie = new HttpCookie("aUserID");
                    aCookie.Values["aUserID"] = userInfo.userID.ToString().Trim();
                    aCookie.Values["aUserName"] = userInfo.userName.ToString().Trim(); 
                    aCookie.Expires.AddDays(3);
                    Response.Cookies.Add(aCookie);
                    Session["userID"] = userInfo.userID.ToString().Trim();
                    Session["userInfo"] = userInfo;

                    Response.Redirect("Default.aspx");
                }
                else
                {
                    //lblError.Text = dataLayer.ErrorMessage;
                    throw new Exception("Invalid Email ID and Password combination.");
                }
            }
            catch (Exception error)
            {
                Response.Write("<script>alert('" + error.Message + "')</script>");
            }
        }
    }
}