<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGyerek.aspx.cs" Inherits="FejlesztokozpontWeb.AddGyerek" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Név"></asp:Label>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Szül.Nap:"></asp:Label>
    <asp:Calendar ID="calendarBirthDay" runat="server"></asp:Calendar>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Terapeuta"></asp:Label>
    <asp:DropDownList ID="ddlTerapeutak" runat="server"></asp:DropDownList>
</asp:Content>
