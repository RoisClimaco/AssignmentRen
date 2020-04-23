<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MyProjectSite2.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <table class="tdBodyIn" align="center">
                <tr  height="30px">
                    <td colspan="3" ><h1>REGISTER</h1><hr /></td>
                </tr>
                <tr  height="5px">
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
        
                <tr  height="20px">
                    <td class="fieldLabel">
                        Email ID :
                    </td>
                    <td class="inputEntry"  >
                        <asp:TextBox ID="txtEmailID" runat="server" Width="250px"></asp:TextBox>
                    </td>
                    <td class="validation">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmailAddress" runat="server" ControlToValidate="txtEmailID" ErrorMessage="Please Enter Email Address" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="txtEmailID" ErrorMessage="Please Enter Valid Email Address" Text="!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    
                    
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
                 <tr  height="20px">
                    <td class="fieldLabel">
                        Confirm Password :
                    </td>
                    <td class="inputEntry"  >
                        <asp:TextBox ID="txtConfirmPassword" runat="server" Width="249px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="validation">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Please Enter Confirm Password" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password and Confirm Password should be the same." Text="!" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword"></asp:CompareValidator>
                    </td>
                </tr>
                <tr height="5px">
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr  height="20px">
                    <td class="fieldLabel">
                        Name :
                    </td>
                    <td class="inputEntry"  >
                        <asp:TextBox ID="txtName" runat="server" Width="400px"></asp:TextBox>
                    </td>
                    <td class="validation">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="Please Enter Your Name" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr  height="20px">
                    <td class="fieldLabel">
                        Contact No. :
                    </td>
                    <td class="inputEntry"  >
                        <asp:TextBox ID="txtContactNo" runat="server" Width="200px" TextMode="Phone"> </asp:TextBox>
                    </td>
                    <td class="validation">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Please Enter Contact No" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                       <asp:RegularExpressionValidator runat="server" ErrorMessage="Contact No should be numeric only" Text="*" ControlToValidate="txtContactNo"
                            ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                </tr>
                <tr  height="20px">
                    <td class="fieldLabel">
                        Gender :
                    </td>
                    <td class="inputEntry" style="text-align:left"  >
                            <asp:RadioButtonList ID="rdoGender" runat="server"  >
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>

                    </td>
                    <td class="validation">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="rdoGender" ErrorMessage="Please Select Gender" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
        
                <tr  height="5px">
                    <td style="height:10px;">
                        &nbsp;
                    </td>
                </tr>
                <tr  height="20px">
                    <td>&nbsp;</td>
                    <td colspan="2" class="inputEntry">
                        <asp:Button ID="btnSave" runat="server" Text="Register" Width="94px" CssClass="buttonStyle" OnClick="btnSave_Click"  />&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="93px"  CssClass="buttonStyle" CausesValidation="False"  OnClick="btnCancel_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td colspan="2" class="validation">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
</asp:Content>
