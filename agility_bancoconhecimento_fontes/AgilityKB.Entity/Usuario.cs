using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilityKB.Entity
{
    public class Usuario
    {
        public Usuario()
        {
            IdUsuario = 0;
            Nome = string.Empty;
            Email = string.Empty;
            Telefone = string.Empty;
            Ramal = string.Empty;
            Celular = string.Empty;
            Skype = string.Empty;
            Foto = string.Empty;
            Senha = string.Empty;
            Imagem = string.Empty;
            Departamento = string.Empty;
            Ativo = false;
            UltimoPost = string.Empty;
            Logado = false;
            Administrador = false;
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Ramal { get; set; }
        public string Celular { get; set; }
        public string Skype { get; set; }
        public string Foto { get; set; }
        public string Senha { get; set; }
        public string Imagem { get; set; }
        public string Departamento { get; set; }
        public bool Ativo { get; set; }
        public string UltimoPost { get; set; }
        public bool Logado { get; set; }
        public bool Administrador { get; set; }
    }
}
