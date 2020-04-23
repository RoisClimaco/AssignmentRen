using MyProjectSite1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyProjectSite2
{
    /* Reviewed By: ROLANDO
     * Curly brackets are on the next line; it should be on the same line as the condition / method names
     * Commented codes should be removed
     **/
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessLayer dataLayer = new DataAccessLayer();

                int iUserID = dataLayer.AddUser(txtEmailID.Text.Trim(), txtPassword.Text.Trim(),   txtContactNo.Text.Trim(), txtName.Text.Trim(),rdoGender.SelectedValue.ToString().Trim());
                if (iUserID > 0)
                {
                    Response.Redirect("Login.aspx");
                }
                else if (dataLayer.ErrorMessage.Trim() != "")
                {

                    throw new Exception(dataLayer.ErrorMessage.Trim());
                }
            }
            catch (CustomException.UserRegistrationFailedException error)
            {
                Response.Write("<script>alert('" + error.Message + "')</script>");
            }
            catch (System.Exception error2)
            {
                Response.Write("<script>alert('" + error2.Message + "')</script>");
                //Response.Write("<script>alert('Unknown Exception, Please Contact Administrator!')</script>");
               // throw new HttpException(500, "Internal Server Error");
            }
}

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}