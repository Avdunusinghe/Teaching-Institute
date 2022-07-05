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
        OnRowUpdating="btn_update_Click"
        OnRowDeleting="btn_delete_Click"
        runat="server"
        class="table table-striped">
        <Columns>
            <asp:DynamicField DataField ="Id" />
            <asp:DynamicField DataField ="FirstName" />
            <asp:DynamicField DataField ="LastName" />
            <asp:DynamicField DataField ="Address" />
            <asp:DynamicField DataField ="MobileNumber" />
            <asp:DynamicField DataField ="Birthday" />
            <asp:DynamicField DataField ="CreatedDate" />
            <asp:TemplateField>  
                    <ItemTemplate> 
                      <asp:Button ID="btn_update" runat="server" Text="Update"  class="btn btn-success" CommandName="update"  OnClick="btn_update_Click"  CommandArgument='<%# Eval("Id") %>' />  
                       <asp:Button ID="btn_delete" runat="server" Text="Delete"  class="btn btn-danger" CommandName="delete" OnClick="btn_delete_Click"  CommandArgument='<%# Eval("Id") %>'/>  
                    </ItemTemplate>  
                </asp:TemplateField>  
           
        </Columns>
    </asp:GridView>
</asp:Content>

