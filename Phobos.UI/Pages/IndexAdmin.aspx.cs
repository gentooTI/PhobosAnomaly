using Phobos.BLL;
using Phobos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phobos.UI.Pages
{
    public partial class IndexAdmin : System.Web.UI.Page
    {
        //instanciando objetos
        UsuarioDTO objModeloUser = new UsuarioDTO();
        UsuarioBLL objBLLUser = new UsuarioBLL();

        //metodo para popular o dgv1
        public void PopularGVUser()
        {
            dgv1.DataSource = objBLLUser.ListarUsuario();
            dgv1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopularGVUser();
                lblMessage.Text = String.Empty;
            }

            //iniciando session
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void dgv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {
                objModeloUser.NomeUsuario = (dgv1.FooterRow.FindControl("txtNomeUsuarioFooter") as TextBox).Text.Trim();
                objModeloUser.SenhaUsuario = (dgv1.FooterRow.FindControl("txtSenhaUsuarioFooter") as TextBox).Text.Trim();
                objModeloUser.EmailUsuario = (dgv1.FooterRow.FindControl("txtEmailUsuarioFooter") as TextBox).Text.Trim();

                //ajustando a data

                DateTime dt = DateTime.Parse((dgv1.FooterRow.FindControl("txtDataNascUsuarioFooter") as TextBox).Text.Trim());
                objModeloUser.DataNascUsuario = dt.ToString("yyyy/MM/dd");


                objModeloUser.UsuarioTp = (dgv1.FooterRow.FindControl("rbl1") as RadioButtonList).Text.Trim();

                objBLLUser.CadastrarUser(objModeloUser);
                PopularGVUser();
                (dgv1.FooterRow.FindControl("txtNomeUsuarioFooter") as TextBox).Focus();
                lblMessage.Text = "Usuário " + objModeloUser.NomeUsuario + " cadastrado com Sucesso !!";
            }
        }

        protected void dgv1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            objModeloUser.NomeUsuario = (dgv1.Rows[e.RowIndex].FindControl("txtNomeUsuario") as TextBox).Text.Trim();
            objModeloUser.EmailUsuario = (dgv1.Rows[e.RowIndex].FindControl("txtEmailUsuario") as TextBox).Text.Trim();
            objModeloUser.SenhaUsuario = (dgv1.Rows[e.RowIndex].FindControl("txtSenhaUsuario") as TextBox).Text.Trim();
            objModeloUser.DataNascUsuario = (dgv1.Rows[e.RowIndex].FindControl("txtDataNascUsuario") as TextBox).Text.Trim();
            objModeloUser.UsuarioTp = (dgv1.Rows[e.RowIndex].FindControl("rbl1") as RadioButtonList).Text.Trim();


            objModeloUser.idUsuario = Convert.ToInt32(dgv1.DataKeys[e.RowIndex].Value.ToString());

            objBLLUser.EditUser(objModeloUser);

            dgv1.EditIndex = -1;

            PopularGVUser();

            lblMessage.Text = "Usuário " + objModeloUser.NomeUsuario + " editado com sucesso !!";
        }

        protected void dgv1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objModeloUser.idUsuario = Convert.ToInt32(dgv1.DataKeys[e.RowIndex].Value.ToString());
            objBLLUser.DeleteUser(objModeloUser.idUsuario);
            PopularGVUser();
            lblMessage.Text = "Usuário " + objModeloUser.NomeUsuario + " eliminado com Sucesso !!";
        }

        protected void dgv1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgv1.EditIndex = e.NewEditIndex;
            PopularGVUser();
        }

        protected void dgv1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgv1.EditIndex = -1;
            PopularGVUser();
        }
    }
}