<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="TeachingInstitute.WebApp.StudentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView 
        ID="gridStudentList" 
        ItemType="TeachingInstitute.Model.Student"
        DataKeyNames="Id" 
        AutoGenerateColumns="false"
        AllowPaging="true" 
        PageSize="3"
        OnPageIndexChanging="GridPageIndexChange"
        OnRowEditing="gridStudentList_RowEditing"
        OnRowDeleting="gridStudentList_RowDeleting"
        runat="server">
        <Columns>
            <asp:DynamicField DataField ="Id" />
            <asp:DynamicField DataField ="FirstName" />
            <asp:DynamicField DataField ="LastName" />
            <asp:DynamicField DataField ="Address" />
            <asp:DynamicField DataField ="MobileNumber" />
            <asp:DynamicField DataField ="Birthday" />
            <asp:DynamicField DataField ="CreatedDate" />
            <asp:CommandField ShowEditButton ="true" />
            <asp:CommandField ShowDeleteButton ="true" />

        </Columns>
    </asp:GridView>
</asp:Content>

