using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

using AgilityKB.Entity;
using AgilityKB.DAO;

namespace AgilityKB.Business
{
    public class ArvoreBusiness
    {
        public HierarquiaArvore MontaArvore()
        {
            HierarquiaArvore arvore = new HierarquiaArvore();
            ArvoreDAO arvoreDAO = new ArvoreDAO();

            arvore = arvoreDAO.PopulaArvore();

            return arvore;
        }

        public HierarquiaArvore ListaGalhos(string descricaoNoPai)
        {
            HierarquiaArvore arvore = new HierarquiaArvore();
            ArvoreDAO arvoreDAO = new ArvoreDAO();

            arvore = arvoreDAO.ListaGalhos(descricaoNoPai);

            return arvore;
        }

        public DataTable ListaPosts(String IdNode)
        {
            DataTable dt;

            HierarquiaArvore.Arvore galho = new HierarquiaArvore.Arvore();
            ArvoreDAO arvoreDAO = new ArvoreDAO();

            dt = arvoreDAO.ListaPosts(IdNode);

            return dt;
        }

        public DataTable BuscaPost(String IdPost)
        {
            DataTable dt;

            HierarquiaArvore.Arvore galho = new HierarquiaArvore.Arvore();
            ArvoreDAO arvoreDAO = new ArvoreDAO();

            dt = arvoreDAO.BuscaPost(IdPost);

            return dt;
        }

        public DataTable ListaCategoriasHome()
        {
            ArvoreDAO arvoreDAO = new ArvoreDAO();
            DataTable dt = arvoreDAO.ListaCategoriasHome();

            return dt;
        }
    }
}
