﻿using Phobos.BLL;
using Phobos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phobos.UI.Pages
{
    public partial class IndexAdminFilme : System.Web.UI.Page
    {
        //instanciando objetos Filme
        FilmeDTO objModeloFilme = new FilmeDTO();
        FilmeBLL objBLLFilme = new FilmeBLL();

        //metodo PopularGVFilme
        public void PopularGVFilme()
        {
            dgv2.DataSource = objBLLFilme.ListaFilme();
            dgv2.DataBind();
        }

        //messageBox com JS
        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        //validacao Filme
        private bool ValidaPage()
        {
            bool PageValido;
            if (string.IsNullOrEmpty((dgv2.FooterRow.FindControl("txtTituloFilmeFooter") as TextBox).Text.Trim()))
            {
                MsgBox("Digite o Titulo!", Page, this);
                (dgv2.FooterRow.FindControl("txtTituloFilmeFooter") as TextBox).Focus();
                PageValido = false;
            }
            else if (string.IsNullOrEmpty((dgv2.FooterRow.FindControl("txtGeneroFilmeFooter") as TextBox).Text.Trim()))
            {
                MsgBox("Digite o Genero!", Page, this);
                (dgv2.FooterRow.FindControl("txtGeneroFilmeFooter") as TextBox).Focus();
                PageValido = false;
            }
            else if (string.IsNullOrEmpty((dgv2.FooterRow.FindControl("txtProdutoraFilmeFooter") as TextBox).Text.Trim()))
            {
                MsgBox("Digita o Produtora!", Page, this);
                (dgv2.FooterRow.FindControl("txtProdutoraFilmeFooter") as TextBox).Focus();
                PageValido = false;
            }
            else if ((dgv2.FooterRow.FindControl("rbl1") as RadioButtonList).SelectedIndex < 0)
            {
                MsgBox("Escolha uma das opções!", this.Page, this);
                (dgv2.FooterRow.FindControl("rbl1") as RadioButtonList).Focus();
                PageValido = false;

            }
            else if (!(dgv2.FooterRow.FindControl("fUp1") as FileUpload).HasFile)
            {
                MsgBox("Selecione uma imagem", Page, this);
                (dgv2.FooterRow.FindControl("fUp1") as FileUpload).Focus();
                PageValido = false;
            }

            else
            {
                PageValido = true;
            }
            return PageValido;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopularGVFilme();
                lblMessageF.Text = string.Empty;
            }

            //iniciando Session
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void dgv2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {
                if (ValidaPage())
                {

                objModeloFilme.Titulo = (dgv2.FooterRow.FindControl("txtTituloFilmeFooter") as TextBox).Text.Trim();
                objModeloFilme.Genero = (dgv2.FooterRow.FindControl("txtGeneroFilmeFooter") as TextBox).Text.Trim();
                objModeloFilme.Produtora = (dgv2.FooterRow.FindControl("txtProdutoraFilmeFooter") as TextBox).Text.Trim();

                //saving image
                if ((dgv2.FooterRow.FindControl("fUp1") as FileUpload).HasFile)
                {
                    var str = (dgv2.FooterRow.FindControl("fUp1") as FileUpload).FileName.Trim();
                    (dgv2.FooterRow.FindControl("fUp1") as FileUpload).PostedFile.SaveAs(Server.MapPath("~/img" + "/" + str));
                    string CaminhoImg = "~/img" + "/" + str.ToString();
                    objModeloFilme.UrlImagem = CaminhoImg;
                }

                objModeloFilme.idClassificacao = (dgv2.FooterRow.FindControl("rbl1") as RadioButtonList).Text.Trim();

                objBLLFilme.CadastrarFilme(objModeloFilme);
                PopularGVFilme();
                (dgv2.FooterRow.FindControl("txtTituloFilmeFooter") as TextBox).Focus();
                lblMessageF.Text = "O Filme " + objModeloFilme.Titulo + " cadastrado com sucesso !!";

                }
            }
        }

        protected void dgv2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgv2.EditIndex = e.NewEditIndex;
            PopularGVFilme();
        }

        protected void dgv2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgv2.EditIndex = -1;
            PopularGVFilme();
        }

        protected void dgv2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            objModeloFilme.Titulo = (dgv2.Rows[e.RowIndex].FindControl("txtTituloFilme") as TextBox).Text.Trim();

            objModeloFilme.Genero = (dgv2.Rows[e.RowIndex].FindControl("txtGeneroFilme") as TextBox).Text.Trim();

            objModeloFilme.Produtora = (dgv2.Rows[e.RowIndex].FindControl("txtProdutoraFilme") as TextBox).Text.Trim();

            //saving image
            if ((dgv2.Rows[e.RowIndex].FindControl("fUp1") as FileUpload).HasFile)
            {
                var str = (dgv2.Rows[e.RowIndex].FindControl("fUp1") as FileUpload).FileName.Trim();
                (dgv2.Rows[e.RowIndex].FindControl("fUp1") as FileUpload).PostedFile.SaveAs(Server.MapPath("~/img" + "/" + str));
                string CaminhoImg = "~/img" + "/" + str.ToString();
                objModeloFilme.UrlImagem = CaminhoImg;
            }


            objModeloFilme.idClassificacao = (dgv2.Rows[e.RowIndex].FindControl("rbl1") as RadioButtonList).Text.Trim();

            objModeloFilme.idFilme = Convert.ToInt32(dgv2.DataKeys[e.RowIndex].Value.ToString());

            objBLLFilme.EditFilme(objModeloFilme);
            dgv2.EditIndex = -1;

            PopularGVFilme();

            lblMessageF.Text = "Filme " + objModeloFilme.Titulo + " editado com sucesso !!";
        }

        protected void dgv2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objModeloFilme.idFilme = Convert.ToInt32(dgv2.DataKeys[e.RowIndex].Value.ToString());
            objBLLFilme.DeleteFilme(objModeloFilme.idFilme);
            PopularGVFilme();
            (dgv2.FooterRow.FindControl("txtTituloFilmeFooter") as TextBox).Focus();

            lblMessageF.Text = "O Filme " + objModeloFilme.Titulo + " foi eliminado com sucesso!!";
        }
    }
}