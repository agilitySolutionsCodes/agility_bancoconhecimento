using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace AgilityKB.DAO
{
    public class Conexao
    {
        private SqlConnection conexao;

        public Conexao()
        {
            AppSettingsReader app = new AppSettingsReader();
            string ambiente = app.GetValue("Ambiente", typeof(String)).ToString();

            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings[ambiente].ConnectionString);
        }

        public SqlConnection AbrirConexao()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed || conexao.State == ConnectionState.Broken)
                {
                    conexao.Open();
                }

                else
                {
                    conexao.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return conexao;
        }
    }
}
