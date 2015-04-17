using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

using AgilityKB.Entity;
using AgilityKB.DAO;

namespace AgilityKB
{
    public class PostsDAO
    {
        public SqlCommand sqlCmd;
        public SqlParameter sqlPm;

        public void RegistrarPost(string titulo, string conteudo, string anexo, DateTime data, string hora, string idUsuario, int idContexto)
        {
            Conexao cnx = new Conexao();
            SqlConnection sqlCon = new SqlConnection();

            sqlCon = cnx.AbrirConexao();
            sqlCmd = new SqlCommand("STP_Incluir_Post", sqlCon);
            sqlPm = new SqlParameter("@P_IdPost", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            Posts post = new Posts();

            post.Titulo = titulo;
            post.Conteudo = conteudo;
            post.Anexo = anexo;
            post.Data = data;
            post.Hora = hora;
            post.IdUsuario = Convert.ToInt32(idUsuario);
            post.IdContexto = idContexto;

            sqlCmd.Parameters.Add(new SqlParameter("@P_Titulo", post.Titulo));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Conteudo", post.Conteudo));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Anexo", post.Anexo));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Data", post.Data));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Hora", post.Hora));
            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", post.IdUsuario));
            sqlCmd.Parameters.Add(new SqlParameter("@P_IdContexto", post.IdContexto));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
            sqlCon.Close();
        }

        public void RegistrarCategoria(string descricao, int abaixoPai, int profundidade)
        {
            Conexao cnx = new Conexao();
            SqlConnection sqlCon = new SqlConnection();

            sqlCon = cnx.AbrirConexao();
            sqlCmd = new SqlCommand("STP_Incluir_Categoria", sqlCon);
            sqlPm = new SqlParameter("@P_IdNode", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_DescricaoNode", descricao));
            sqlCmd.Parameters.Add(new SqlParameter("@P_AbaixoPai", abaixoPai));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Profundidade", profundidade));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
            sqlCon.Close();

        }

        public DataTable Busca(String palavraChave)
        {
            DataTable dt = new DataTable();

            Conexao cnx = new Conexao();
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = cnx.AbrirConexao();


            sqlCmd = new SqlCommand("STP_Busca", sqlCon);
            sqlPm = new SqlParameter("@P_PalavraChave", SqlDbType.VarChar);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_PalavraChave", palavraChave));
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            sqlCon.Close();

            da.Fill(dt);
            return dt;
        }

    }
}
