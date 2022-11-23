<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultAdmin.Master" AutoEventWireup="true" CodeBehind="IndexAdmin.aspx.cs" Inherits="Phobos.UI.Pages.IndexAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="base">
        <h1 id="User">Users</h1>
        <asp:GridView runat="server" ID="dgv1" GridLines="None" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="idUsuario" OnRowCommand="dgv1_RowCommand" OnRowUpdating="dgv1_RowUpdating" OnRowDeleting="dgv1_RowDeleting" OnRowEditing="dgv1_RowEditing" OnRowCancelingEdit="dgv1_RowCancelingEdit">
            <Columns>
                <%--Templete Nome--%>
                <asp:TemplateField HeaderText="Nome">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("NomeUsuario") %>' />
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtNomeUsuario" MaxLength="50" Text='<%#Eval("NomeUsuario") %>' />
                    </EditItemTemplate>

                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="txtNomeUsuarioFooter" MaxLength="50" />
                    </FooterTemplate>

                </asp:TemplateField>

                <%--Templete Email--%>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("EmailUsuario") %>' />
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtEmailUsuario" MaxLength="50" Text='<%#Eval("EmailUsuario") %>' />
                    </EditItemTemplate>

                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="txtEmailUsuarioFooter" MaxLength="50" />
                    </FooterTemplate>

                </asp:TemplateField>

                <%--Templete Senha--%>
                <asp:TemplateField HeaderText="Senha">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("SenhaUsuario") %>' />
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtSenhaUsuario" MaxLength="6" Text='<%#Eval("SenhaUsuario") %>' />
                    </EditItemTemplate>

                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="txtSenhaUsuarioFooter" MaxLength="50" />
                    </FooterTemplate>
                </asp:TemplateField>

                <%--Templete DataNascUsuario--%>
                <asp:TemplateField HeaderText="Data Nascimento">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("DataNascUsuario") %>' />
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtDataNascUsuario" MaxLength="50" Text='<%#Eval("DataNascUsuario") %>' />
                    </EditItemTemplate>

                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="txtDataNascUsuarioFooter" MaxLength="50" />
                    </FooterTemplate>

                </asp:TemplateField>

                <%--Templete UsuarioTP--%>
                <asp:TemplateField HeaderText="Tipo Usuario">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("UsuarioTp") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:RadioButtonList runat="server" ID="rbl1">
                            <asp:ListItem Value="1" Text="Administrador" />
                            <asp:ListItem Value="2" Text="Outros" />
                        </asp:RadioButtonList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:RadioButtonList runat="server" ID="RadioButtonList1">
                            <asp:ListItem Value="1" Text="Administrador" />
                            <asp:ListItem Value="2" Text="Outros" />
                        </asp:RadioButtonList>
                    </FooterTemplate>
                </asp:TemplateField>

                <%--button--%>
                <asp:TemplateField HeaderText="Opções">

                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="btnEditar" ImgUrl="~/img/editB.png" ToolTip="Editar" Width="30" Height="30" CommandName="Edit" />
                        <asp:ImageButton runat="server" ID="btnExcluir" ImgUrl="~/img/deleteB.png" ToolTip="Excluir" Width="30" Height="30" CommandName="Delete" OnClientClick="if (!confirm('Deseja realmente eliminar esse registro) return false" />
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:ImageButton runat="server" ID="btnSalvar" ImgUrl="~/img/saveB.png" ToolTip="Salvar" Width="30" Height="30" CommandName="Update" />
                        <asp:ImageButton runat="server" ID="btnCancelar" ImgUrl="~/img/cancelB.png" ToolTip="Cancelar" Width="30" Height="30" CommandName="Cancel" />
                    </EditItemTemplate>

                    <FooterTemplate>
                        <asp:ImageButton runat="server" ID="btnAdicionar" ImgUrl="~/img/addB.png" ToolTip="Adicionar" Width="30" Height="30" CommandName="Add" />
                    </FooterTemplate>

                </asp:TemplateField>

            </Columns>

        </asp:GridView>
        <br />
        <asp:Label runat="server" ID="lblMessage" Text="Label"/>

    </div>
</asp:Content>
