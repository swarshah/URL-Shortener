<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin:0 auto; text-align:center">
        <h2><b>URL Shorting Made Easy</b></h2>
    </div>
    <div class="form-inline" style="text-align: center">
        <label for="ContentPlaceHolder1_url">Enter URL:</label>
        <asp:TextBox id="url" runat="server" class="form-control"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" class="btn btn-primary"/>
    </div>

</asp:Content>

