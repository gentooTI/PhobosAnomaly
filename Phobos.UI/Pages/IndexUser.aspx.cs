using Phobos.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phobos.UI.Pages
{
    public partial class IndexUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioBLL objUser = new UsuarioBLL();
            dgv1.DataSource = objUser.ListaUsuario(); //popular objeto
            dgv1.DataBind(); //imprimindo na tela

            FilmeBLL objFilme = new FilmeBLL();
            dgv2.DataSource = objFilme.ListaFilme(); //popular objeto
            dgv2.DataBind(); //imprimindo na tela
        }
    }
}