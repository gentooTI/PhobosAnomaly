<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultUser.Master" AutoEventWireup="true" CodeBehind="ConsultaUser.aspx.cs" Inherits="Phobos.UI.Pages.ConsultaUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="geral">
        <asp:GridView runat="server" ID="dgv1" GridLines="None" AutoGenerateColumns="false" BackColor="Silver">
            <columns>
                <asp:BoundField DataField="NomeUsuario" HeaderText="Name" />
                <asp:BoundField DataField="EmailUsuario" HeaderText="Email" />
                <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
            </columns>
        </asp:GridView>
    </div>
</asp:Content>
