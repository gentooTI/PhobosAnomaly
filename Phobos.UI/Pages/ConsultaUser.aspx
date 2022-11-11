<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultUser.Master" AutoEventWireup="true" CodeBehind="ConsultaUser.aspx.cs" Inherits="Phobos.UI.Pages.ConsultaUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="geral">
        <asp:GridView runat="server" ID="dgv1" GridLines="None" AutoGenerateColumns="false" BackColor="Silver">
            <columns>
                <asp:BoundField DataField="NomeUsuario" HeardText="Name" />
                <asp:BoundField DataField="EmailUsuario" HeardText="Email" />
                <asp:BoundField DataField="Descricao" HeardText="Description" />
            </columns>
        </asp:GridView>
    </div>
</asp:Content>
