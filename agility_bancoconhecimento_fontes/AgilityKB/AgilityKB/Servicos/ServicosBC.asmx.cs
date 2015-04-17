using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using System.Data.SqlClient;
using System.Web.Script.Services;


using AgilityKB.DAO;

namespace AgilityKB.Servicos
{
    /// <summary>
    /// Summary description for ServicosBC
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServicosBC : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public DadosPost GetLink(string idPost)
        {
            DadosPost d = new DadosPost();
            Conexao conexao = new Conexao();
            SqlConnection dbCon = conexao.AbrirConexao();
            SqlCommand cmd = new SqlCommand("STP_Busca_Post", dbCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@P_IdPost", System.Data.SqlDbType.VarChar, 10).Value = idPost;
            cmd.Prepare();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                d = new DadosPost(dr["IdPost"], dr["Titulo"], dr["Conteudo"], dr["Nome"], dr["Data"], dr["Anexo"]);
                dr.Close();
            }
            return d;
        }
    }

    [Serializable]
    public class DadosPost
    {
        private int idPost;
        private string titulo;
        private string conteudo;
        private string nomeUsuario;
        private string data;
        private string anexoPost;
        private string nomeArq;
        private string caminhoArq;

        public int IdPost { get { return idPost; } set { idPost = value; } }
        public string Titulo { get { return titulo; } set { titulo = value; } }
        public string Conteudo { get { return conteudo; } set { conteudo = value; } }
        public string NomeUsuario { get { return nomeUsuario; } set { nomeUsuario = value; } }
        public string Data { get { return data; } set { data = value; } }
        public string AnexoPost { get { return anexoPost; } set { anexoPost = value; } }
        public string NomeArq { get { return nomeArq; } set { nomeArq = value; } }
        public string CaminhoArq { get { return caminhoArq; } set { caminhoArq = value; } }


        public DadosPost()
        {
            this.idPost = -1;
            this.titulo = "";
            this.conteudo = "";
            this.nomeUsuario = "";
            this.data = "";
            this.anexoPost = "";
            this.nomeArq = "";
            this.caminhoArq = "";
        }

        public DadosPost(object idPost, object titulo, object conteudo, object nomeUsuario, object data, object anexoPost)
        {
            this.idPost = Convert.ToInt32(idPost);
            this.titulo = titulo.ToString();
            this.conteudo = conteudo.ToString();
            this.nomeUsuario = "Por: " + " " + nomeUsuario;
            this.data = " " + "Em: " + " " + Convert.ToDateTime(data).ToString("dd/MM/yyyy");

            if (!string.IsNullOrEmpty(anexoPost.ToString()))
            {
                nomeArq = "Donwload: " + anexoPost.ToString();
                caminhoArq = "/BancoConhecimento/Uploads/" + anexoPost.ToString();
            }
            else
            {
                nomeArq = string.Empty;
                this.anexoPost = string.Empty;
            }
        }
    }
}
