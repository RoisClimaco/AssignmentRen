<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyProjectSite1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome Institute of Studies</title>
        <link rel="stylesheet" href="register.css" type="text/css" media="screen" />
     <link rel="stylesheet" href="login.css" type="text/css" media="screen" />
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
    <!-- Test -->
<body>
    <header style="background-color:white;text-align:center;height:220px;width:92%;vertical-align:middle;">
       <img id="logo" src="images/logo.jpg" style="text-align:center;width:80%;height:250px" />
       <hr />
   </header>
    <form id="form1" runat="server">
        <br />
       <div style="padding-left:50px;padding-top:40px;">
            <table class="tdBodyIn" align="center">
                <tr height="50px">
                    <td colspan="3" class="tdH1"><h1 class="auto-style1">LOGIN</h1></td>
                </tr>
                <tr  height="5px">
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr  height="15px">
                    <td class="auto-style2">
                        &nbsp;
                    </td>
                    <td colspan="2" class="tdLink">
                        <a href="Register.aspx">Not yet a Registered User</a>
                    </td>
                </tr>
                <tr  height="20px">
                    <td class="fieldLabel" width="100px">
                        Email ID :
                    </td>
                    <td class="inputEntry"  >
                        <asp:TextBox ID="txtEmailID" runat="server" Width="250px"></asp:TextBox>
                    </td>
                    <td class="validation" width="150px">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="txtEmailID" ErrorMessage="Please Enter Valid Email Address" Text="!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmailAddress" runat="server" ControlToValidate="txtEmailID" ErrorMessage="Please Enter Email Address" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr  height="20px">
                    <td class="fieldLabel">
                        Password :
                    </td>
                    <td class="inputEntry"  >
                        <asp:TextBox ID="txtPassword" runat="server" Width="249px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="validation">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Enter Password" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr  height="5px">
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr  height="20px">
                    <td>&nbsp;</td>
                    <td colspan="2" class="inputEntry">
                        <asp:Button ID="btnOK" runat="server" Text="OK" Width="94px" CssClass="buttonStyle" OnClick="btnOK_Click"  />&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="93px"  CssClass="buttonStyle" CausesValidation="false"/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td colspan="2" class="validation">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td colspan="2" class="validation">
                        &nbsp;
                    </td>
                </tr>
            </table>
        
        </div>
    </form>
</body>
</html>
