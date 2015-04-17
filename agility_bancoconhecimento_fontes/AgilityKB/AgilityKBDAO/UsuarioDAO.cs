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


namespace AgilityKB.DAO
{
    public class UsuarioDAO
    {
        public SqlCommand sqlCmd;
        public SqlParameter sqlPm;

        public void IncluirUsuario(string nome, string email, string telefone, string ramal,
                                   string celular, string nomeSkype, string foto, string senha, string img, string dpto)
        {
            Conexao cnx = new Conexao();
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = cnx.AbrirConexao();
            sqlCmd = new SqlCommand("STP_Incluir_Usuario", sqlCon);

            sqlPm = new SqlParameter("@P_IdUsuario", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            Usuario usuario = new Usuario();

            usuario.Nome = nome;
            usuario.Email = email;
            usuario.Telefone = telefone;
            usuario.Ramal = ramal;
            usuario.Celular = celular;
            usuario.Skype = nomeSkype;
            usuario.Foto = foto;
            usuario.Senha = senha;
            usuario.Imagem = img;
            usuario.Departamento = dpto;

            sqlCmd.Parameters.Add(new SqlParameter("@P_Nome", usuario.Nome));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Email", usuario.Email));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Telefone", usuario.Telefone));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Ramal", usuario.Ramal));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Celular", usuario.Celular));
            sqlCmd.Parameters.Add(new SqlParameter("@P_NomeSkype", usuario.Skype));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Foto", usuario.Foto));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Senha", usuario.Senha));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Imagem", usuario.Imagem));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Departamento", usuario.Departamento));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
            sqlCon.Close();
        }

        public DataTable ListaUsuarios()
        {
            DataTable dt = new DataTable();
            Conexao cnx = new Conexao();
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = cnx.AbrirConexao();
            sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "  SELECT IdUsuario, Nome, Email, Telefone, Ramal, Celular,  NomeSkype, Foto, Senha, Imagem, Departamento FROM Usuarios (NOLOCK)";
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable ListaUsuarioById(int IdUsuario)
        {
            DataTable dt = new DataTable();
            Conexao cnx = new Conexao();
            SqlConnection sqlCon = new SqlConnection();

            sqlCon = cnx.AbrirConexao();
            sqlCmd = new SqlCommand("STP_Lista_Usuario_ById", sqlCon);
            sqlPm = new SqlParameter("@P_IdUsuario", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", IdUsuario));
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            sqlCon.Close();

            da.Fill(dt);
            return dt;

        }

        public void DeletaUsuario(int IdUsuario)
        {
            Conexao cnx = new Conexao();
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = cnx.AbrirConexao();
            sqlCmd = new SqlCommand("STP_Deleta_Usuario", sqlCon);

            sqlPm = new SqlParameter("@P_IdUsuario", SqlDbType.Int);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@P_IdUsuario", IdUsuario));

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
            sqlCon.Close();
        }

        public Usuario AutenticarUsuario(string email, string senha)
        {
            Conexao cnx = new Conexao();
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = cnx.AbrirConexao();
            
            sqlCmd = new SqlCommand("STP_Autenticar_Usuario", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            Usuario usuario = new Usuario();
            usuario.Email = email;
            usuario.Senha = senha;


            sqlCmd.Parameters.Add(new SqlParameter("@P_Email", usuario.Email));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Senha", usuario.Senha));

            sqlCmd.Parameters.Add("@Ok", SqlDbType.Bit).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@CodUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@NomeUsuario", SqlDbType.VarChar, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@ImagemUsuario", SqlDbType.VarChar, 80).Direction = ParameterDirection.Output;
            
            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            usuario.Logado = Convert.ToBoolean(sqlCmd.Parameters["@Ok"].Value);
            usuario.IdUsuario = Convert.ToInt32(sqlCmd.Parameters["@CodUsuario"].Value);
            usuario.Nome = Convert.ToString(sqlCmd.Parameters["@NomeUsuario"].Value);
            usuario.Imagem = Convert.ToString(sqlCmd.Parameters["@ImagemUsuario"].Value);
            
            return usuario;
        }
        
        public Usuario AutenticarUsuarioAdmin(string email, string senha)
        {
            Conexao cnx = new Conexao();
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = cnx.AbrirConexao();

            sqlCmd = new SqlCommand("STP_Autenticar_Administrador", sqlCon);
            sqlCmd.CommandTimeout = sqlCon.ConnectionTimeout;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            Usuario usuario = new Usuario();
            usuario.Email = email;
            usuario.Senha = senha;


            sqlCmd.Parameters.Add(new SqlParameter("@P_Email", usuario.Email));
            sqlCmd.Parameters.Add(new SqlParameter("@P_Senha", usuario.Senha));

            sqlCmd.Parameters.Add("@Ok", SqlDbType.Bit).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@CodUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@NomeUsuario", SqlDbType.VarChar, 80).Direction = ParameterDirection.Output;
            sqlCmd.Parameters.Add("@ImagemUsuario", SqlDbType.VarChar, 80).Direction = ParameterDirection.Output;

            sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);

            usuario.Logado = Convert.ToBoolean(sqlCmd.Parameters["@Ok"].Value);
            usuario.IdUsuario = Convert.ToInt32(sqlCmd.Parameters["@CodUsuario"].Value);
            usuario.Nome = Convert.ToString(sqlCmd.Parameters["@NomeUsuario"].Value);
            usuario.Imagem = Convert.ToString(sqlCmd.Parameters["@ImagemUsuario"].Value);

            return usuario;
        }
    }
}
