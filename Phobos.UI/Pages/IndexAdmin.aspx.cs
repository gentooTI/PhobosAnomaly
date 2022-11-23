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
            dgv1.DataSource = objBLLUser.ListaUsuario();
            dgv1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dgv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dgv1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void dgv1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgv1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgv1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}