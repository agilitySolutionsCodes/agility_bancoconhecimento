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
    public class PostsBusiness
    {
        public Posts RegistrarPost(string titulo, string conteudo, string anexo, DateTime data, string hora, string idUsuario, int idContexto)
        {
            Posts posts = new Posts();
            PostsDAO postsDao = new PostsDAO();

            postsDao.RegistrarPost(titulo, conteudo, anexo, data, hora, idUsuario, idContexto);

            return posts;
        }

        public void RegistrarCategoria(string descricao, int filhoDe, int nivelProfundidade)
        {
            PostsDAO postDao = new PostsDAO();
            postDao.RegistrarCategoria(descricao, filhoDe, nivelProfundidade);
        }

        public DataTable BuscaPosts(String palavraChave)
        {
            DataTable dt;

            HierarquiaArvore.Arvore galho = new HierarquiaArvore.Arvore();
            PostsDAO postDAO = new PostsDAO();

            dt = postDAO.Busca(palavraChave);

            return dt;
        }
    }
}
