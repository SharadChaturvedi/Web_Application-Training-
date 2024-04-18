<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Validation.Validator" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <style>
        body {
            font-family: "Georgia", serif;
            background-color: darkgray;
            margin: 0;
            padding: 20px;
        }

        #form1 {
            background-color:gray;
            width: 500px;
            margin: 50px auto;
            padding: 30px;
            border-radius: 8px;
            border: 2px solid #ccc;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
        }

        label {
            font-weight: bold;
            width: 150px;
            display: inline-block;
            vertical-align: top;
            color: #333;
            font-size: 16px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-group input[type="text"] {
            width: calc(100% - 160px);
            padding: 10px;
            border: 1px solid #999;
            border-radius: 5px;
            box-sizing: border-box;
            font-family: "Georgia", serif;
            font-size: 16px;
            color: #333;
        }

        .error-message {
            color: red;
            font-size: 14px;
            margin-left: 150px;
            margin-top: 5px;
        }

        .submit-btn {
            background-color: #993300;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-family: "Georgia", serif;
            font-size: 16px;
            margin-left: 150px;
        }

        .submit-btn:hover {
            background-color: #660000;
        }

        .validation-summary {
            color: #cc0000;
            margin-top: 10px;
            font-size: 14px;
            margin-left: 150px;
        }

        h3 {
            color: #333;
            text-align: center;
            font-size: 24px;
            margin-bottom: 20px;
        }
    </style>


    
</head>
<body>
    <form id="form1" runat="server">
       <center> <h3 style="color:darkslateblue;"> VALIDATION FORM </h3> </center><br /><br />
        <div style="margin-left: 2px">
          Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server" ForeColor="#FFCC00" BackColor="#FFCC66" BorderColor="#333333"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Name cannot be blank" ForeColor="Red">*</asp:RequiredFieldValidator>
<br />
<br />
            Family Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server" BackColor="#FFCC66" BorderColor="#333333"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="Family Name cannot be blank" ForeColor="Red">*</asp:RequiredFieldValidator>
<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox1" ControlToValidate="TextBox2" ErrorMessage="family name should not be same as Name" ForeColor="Red" Operator="NotEqual">*</asp:CompareValidator>
<br />
<br />
            Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server" BorderColor="#666666" BackColor="#FFCC66"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="Address cannot be blank" ForeColor="Red">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="Address must be atleat two characters long" ForeColor="Red" ValidationExpression=".{2,}">*</asp:RegularExpressionValidator>
<br />
<br />
            City:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox4" runat="server" BackColor="#FFCC66"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="City cannot be blank" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="City must be atleast two characters long" ForeColor="Red" ValidationExpression=".{2,}">*</asp:RegularExpressionValidator>
<br />
<br />
            Zip Code:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox5" runat="server" BackColor="#FFCC66"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox5" ErrorMessage="Zip code cannot be blank" ForeColor="Red">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox5" ErrorMessage="Zip Code must be in 5 digits" ForeColor="Red" ValidationExpression="\d{5}">*</asp:RegularExpressionValidator>
<br />
<br />
            Phone:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox6" runat="server" BackColor="#FFCC66"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox6" ErrorMessage="Phone Number cannot be blank" ForeColor="Red">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox6" ErrorMessage="(XX-XXXXXXXX / XXX-XXXXXXX)" ForeColor="Red" ValidationExpression="^\d{2,3}-\d{7,8}$">*</asp:RegularExpressionValidator>
<br />
<br />
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox7" runat="server" BackColor="#FFCC66"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox7" ErrorMessage="Email cannot be blank" ForeColor="Red">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox7" ErrorMessage="example@gmail.com" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
<br />
<br />
<asp:Button ID="btn" runat="server" Text="Validate" OnClick="btn_Click" />
<br />
<br />
<asp:Label ID="lbl1" runat="server" Text="Validation ERROR" Visible="False"></asp:Label>
<br />
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
<br />
<br />
</div>
</form>
</body>
</html>
