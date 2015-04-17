using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AgilityKB.Entity;
using AgilityKB.Business;
using AgilityKB.Controles;

namespace AgilityKB.Controles
{
    public delegate void SelecionarMenu(string IdNo);
    public delegate void BuscarPosts(string palavraChave);

    public partial class MenuLateral : System.Web.UI.UserControl
    {
        public event SelecionarMenu OnSelecionarMenu;
        public event BuscarPosts OnBuscarPost;

        ArvoreBusiness arvoreB = new ArvoreBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopularArvore();
            }
        }

        public void PopularArvore()
        {
            this.ArvoreBiblioteca.Nodes.Clear();

            HierarquiaArvore hArvore = arvoreB.MontaArvore();

            ArvoreBiblioteca.ExpandDepth = 0;

            foreach (HierarquiaArvore.Arvore galho in hArvore)
            {
                HierarquiaArvore.Arvore noArvore = hArvore.Find
                    (delegate(HierarquiaArvore.Arvore emp)
                    { return emp.IdNode == galho.AbaixoPai; });

                if (noArvore != null)
                {
                    foreach (TreeNode tn in ArvoreBiblioteca.Nodes)
                    {
                        if (tn.Value == noArvore.IdNode.ToString())
                        {
                            tn.ChildNodes.Add(new TreeNode(galho.DescricaoNode.ToString(), galho.IdNode.ToString()));
                            tn.ChildNodes[0].Expanded = false;
                        }

                        if (tn.ChildNodes.Count > 0)
                        {
                            foreach (TreeNode ctn in tn.ChildNodes)
                            {
                                FilhoRecursivo(ctn, noArvore.IdNode.ToString(), galho);
                                tn.ChildNodes[0].Expanded = false;
                            }
                        }
                    }
                }

                else
                {
                    ArvoreBiblioteca.Nodes.Add(new TreeNode(galho.DescricaoNode, galho.IdNode.ToString()));
                    ArvoreBiblioteca.Nodes[0].Expanded = false;
                }
            }

            ArvoreBiblioteca.Nodes[0].Expanded = false;
        }

        public void FilhoRecursivo(TreeNode tn, string valorBusca, HierarquiaArvore.Arvore galho)
        {
            if (tn.Value == valorBusca)
            {
                tn.ChildNodes.Add(new TreeNode(galho.DescricaoNode.ToString(), galho.IdNode.ToString()));
                tn.ChildNodes[0].Expanded = false;
            }

            if (tn.ChildNodes.Count > 0)
            {
                foreach (TreeNode ctn in tn.ChildNodes)
                {
                    FilhoRecursivo(ctn, valorBusca, galho);
                    tn.ChildNodes[0].Expanded = false;
                }
            }
        }

        protected void ArvoreBiblioteca_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (ArvoreBiblioteca.SelectedNode != null)
            {
                if (OnSelecionarMenu != null)
                    OnSelecionarMenu(ArvoreBiblioteca.SelectedNode.Value);
            }
        }

        protected void BtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtBusca.Text))
            {
                if (OnBuscarPost != null)
                {
                    OnBuscarPost(TxtBusca.Text);
                }
            }
        }
    }
}