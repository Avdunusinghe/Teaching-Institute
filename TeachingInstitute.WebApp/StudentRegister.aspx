<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentRegister.aspx.cs" Inherits="TeachingInstitute.WebApp.StudentRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script type="text/javascript" src="Scripts/toastr.js"></script>
     <link href="Content/toastr.css" rel="stylesheet" type="text/css" media="screen" />

    <h2>Student Form</h2>
    <hr />
    <formview>
        <div class="form-group">
            <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
            <asp:TextBox ID="txtFirstName" class="form-control"  runat="server" ></asp:TextBox>
         </div>
         <div class="form-group">
             <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
            <asp:TextBox ID="txtLastName" class="form-control"  runat="server"></asp:TextBox>
        </div>
         <div class="form-group">
             <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
        </div>
         <div class="form-group">
             <asp:Label ID="lblMobileNumber" runat="server" Text="MobileNUmber"></asp:Label>
            <asp:TextBox ID="txtMobileNumber" class="form-control"  runat="server"></asp:TextBox>
        </div>
         <div class="form-group">
             <asp:Label ID="lblBirthDay" runat="server" Text="BirthDay"></asp:Label>
            <asp:TextBox ID="txtBirthDay" class="form-control"  runat="server"></asp:TextBox>
        </div> 
            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Submit" OnClick="SaveStudent"/>
        
       
    </formview>
</asp:Content>
