<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="TeachingInstitute.WebApp.StudentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gridStudentList" ItemType="TeachingInstitute.Model.Student" DataKeyNames="Id" SelectMethod="GetStudentDetails" runat="server">
       
        <Columns>
            <asp:DynamicField DataField ="Id" />
            <asp:DynamicField DataField ="FirstName" />
            <asp:DynamicField DataField ="LastName" />
            <asp:DynamicField DataField ="Address" />
            <asp:DynamicField DataField ="MobileNumber" />
            <asp:DynamicField DataField ="Birthday" />
        </Columns>
    </asp:GridView>
</asp:Content>

