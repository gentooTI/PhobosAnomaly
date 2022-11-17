<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultUser.Master" AutoEventWireup="true" CodeBehind="IndexUser.aspx.cs" Inherits="Phobos.UI.Pages.IndexUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/styleP.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="base">
        <h1 id="user">User</h1>
        <asp:GridView runat="server" ID="dgv1" GridLines="None" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="NomeUsuario" HeaderText="Name" />
                <asp:BoundField DataField="EmailUsuario" HeaderText="Email" />
                <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
            </Columns>
        </asp:GridView>
    </div>

    <div class="base">
        <h1 id="movie">Movie</h1>
        <asp:GridView runat="server" ID="dgv2" GridLines="None" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                <asp:BoundField DataField="Genero" HeaderText="Genero" />
                <asp:BoundField DataField="Produtora" HeaderText="Produtora" />
                <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                <asp:ImageField DataImageUrlField="UrlImagem" HeaderText="Imagem" ControlStyle-Width="150" ControlStyle-Height="150" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
