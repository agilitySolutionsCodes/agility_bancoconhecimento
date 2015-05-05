using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;

using AgilityKB.Entity;
using AgilityKB.Business;
using AgilityKB.Controles;

namespace AgilityKB
{
    public partial class Biblioteca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["CodUsuario"] == null)
                {
                    Response.Redirect("~/default.aspx");
                }
            }

            else
            {
                menuLateral.OnSelecionarMenu += new SelecionarMenu(MenuLateral_OnSelecionarMenu);
                menuLateral.OnBuscarPost += new BuscarPosts(MenuLateral_OnBuscar);

                string IdPost = Request["IdPost"];

                if (IdPost != null)
                {
                    RetornaPost(IdPost);
                }
            }
        }

        public void MenuLateral_OnSelecionarMenu(String IdNo)
        {
            DataTable dt = new DataTable();
            ArvoreBusiness arvoreB = new ArvoreBusiness();

            dt = arvoreB.ListaPosts(IdNo);

            if (dt.Rows.Count > 0)
            {
                litPost.Text = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Rows.Count >= 1)
                    {
                        string conteudo = dr["Titulo"].ToString();
                        DateTime data = Convert.ToDateTime(dr["Data"]);
                        //ConteudoPost.InnerHtml
                        litPost.Text += "<a href='#' class='lnkPosts' onclick=javascript:ChamaPost(" + dr["IdPost"].ToString() + ") >" + dr["Titulo"].ToString()
                                      + "<label class='lblDataPosts'>" + "Por: " + dr["Nome"].ToString() + " " + "Em: " + "" + data.ToString("dd/MM/yyyy") + "</label>"
                                      + "</a>";
                    }
                }
            }

            else
            {
                litPost.Text = "Não Existem Registros de Posts para esta Categoria";
                LblData.Text = string.Empty;
            }

            PnlPost.Update();
        }

        public void MenuLateral_OnBuscar(String palavraChave)
        {
            DataTable dt = new DataTable();
            PostsBusiness postB = new PostsBusiness();

            dt = postB.BuscaPosts(palavraChave);

            if (dt.Rows.Count > 0)
            {
                litPost.Text = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Rows.Count >= 1)
                    {
                        string conteudo = dr["Titulo"].ToString();
                        DateTime data = Convert.ToDateTime(dr["Data"]);
                        //ConteudoPost.InnerHtml
                        litPost.Text += "<a href='#' class='lnkPosts' onclick=javascript:ChamaPost(" + dr["IdPost"].ToString() + ") >" + dr["Titulo"].ToString()
                                      + "<label class='lblDataPosts'>" + "Por: " + dr["Nome"].ToString() + " " + "Em: " + "" + data.ToString("dd/MM/yyyy") + "</label>"
                                      + "</a>";
                    }
                }
            }

            else
            {
                litPost.Text = "Sua busca não encontrou nenhum resultado";
                LblData.Text = string.Empty;
            }

        }

        public void RetornaPost(String IdPost)
        {
            DataTable dt = new DataTable();
            ArvoreBusiness arvoreB = new ArvoreBusiness();

            dt = arvoreB.BuscaPost(IdPost);
            if (dt.Rows.Count > 0)
            {
                DateTime data = Convert.ToDateTime(dt.Rows[0]["Data"]);

                LblTitulo.Text = dt.Rows[0]["Titulo"].ToString();
                ConteudoPost.InnerHtml = dt.Rows[0]["Conteudo"].ToString();
                LblData.Text += "Postado Em: " + "" + data.ToString("dd/MM/yyyy");
                lnkArq.Disabled = false;
                lnkArq.Visible = true;

                PnlPost.Update();
            }
        }
    }
}