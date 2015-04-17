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
    public class ArvoreDAO
    {
        public SqlCommand sqlCmd;
        public SqlParameter sqlPm;

        public HierarquiaArvore PopulaArvore()
        {
            Conexao cnx = new Conexao();
            SqlConnection sqlCon = new SqlConnection();

            sqlCon = cnx.AbrirConexao();
            sqlCmd = new SqlCommand("STP_Monta_Arvore", sqlCon);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            HierarquiaArvore arvore = new HierarquiaArvore();
            HierarquiaArvore.Arvore objArvore = null;

            while (sqlReader.Read())
            {
                objArvore = new HierarquiaArvore.Arvore();

                objArvore.IdNode = int.Parse(sqlReader["IdNode"].ToString());
                objArvore.DescricaoNode = sqlReader["DescricaoNode"].ToString();
                objArvore.AbaixoPai = int.Parse(sqlReader["AbaixoPai"].ToString());
                objArvore.Profundidade = int.Parse(sqlReader["Profundidade"].ToString());
                arvore.Add(objArvore);
            }

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

            return arvore;
        }

        public HierarquiaArvore ListaGalhos(string descricaoNoPai)
        {
            Conexao cnx = new Conexao();
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = cnx.AbrirConexao();

            HierarquiaArvore arvore = new HierarquiaArvore();
            HierarquiaArvore.Arvore objArvore = null;

            sqlCmd = new SqlCommand("STP_Lista_Galhos", sqlCon);
            sqlCmd.Parameters.Add(new SqlParameter("@P_IdNodePai", descricaoNoPai));

            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();


            while (sqlReader.Read())
            {
                objArvore = new HierarquiaArvore.Arvore();

                objArvore.IdNode = int.Parse(sqlReader["IdNode"].ToString());
                objArvore.DescricaoNode = sqlReader["DescricaoNode"].ToString();
                objArvore.AbaixoPai = int.Parse(sqlReader["AbaixoPai"].ToString());
                objArvore.Profundidade = int.Parse(sqlReader["Profundidade"].ToString());
                arvore.Add(objArvore);
            }

            return arvore;
        }

        public DataTable ListaPosts(String IdNode)
        {
            DataTable dt = new DataTable();

            Conexao cnx = new Conexao();
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = cnx.AbrirConexao();


            sqlCmd = new SqlCommand("STP_Lista_Posts", sqlCon);
            sqlPm = new SqlParameter("@P_IdNodeGalho", SqlDbType.VarChar);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdNodeGalho", IdNode));
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            sqlCon.Close();

            da.Fill(dt);
            return dt;
        }

        public DataTable BuscaPost(String IdPost)
        {
            DataTable dt = new DataTable();

            Conexao cnx = new Conexao();
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = cnx.AbrirConexao();


            sqlCmd = new SqlCommand("STP_Busca_Post", sqlCon);
            sqlPm = new SqlParameter("@P_IdPost", SqlDbType.VarChar);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdPost", IdPost));
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            sqlCon.Close();

            da.Fill(dt);
            return dt;
        }

        public DataTable ListaCategoriasHome()
        {
            DataTable dt = new DataTable();

            Conexao cnx = new Conexao();
            SqlConnection sqlCon = new SqlConnection();

            sqlCon = cnx.AbrirConexao();
            sqlCmd = new SqlCommand("STP_Lista_Categorias_Home", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            sqlCon.Close();

            da.Fill(dt);
            return dt;
        }
    }
}
