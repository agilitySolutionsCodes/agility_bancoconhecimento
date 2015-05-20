using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilityKB.Entity
{
    public class Posts
    {
        public int IdPost { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string Categoria { get; set; }
        public string Anexo { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public int IdUsuario { get; set; }
        public int IdContexto { get; set; }
    }
}
