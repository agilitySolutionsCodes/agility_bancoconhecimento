using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilityKB.Entity
{
    public class Categoria
    {
        public Categoria()
        {
            IdCategoria = 0;
            Nome = string.Empty;
            Descricao = string.Empty;
            Imagem = string.Empty;
        }

        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
    }
}
