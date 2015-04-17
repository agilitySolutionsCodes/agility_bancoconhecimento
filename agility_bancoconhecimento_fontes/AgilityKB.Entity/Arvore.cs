using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilityKB.Entity
{
    public class HierarquiaArvore : List<HierarquiaArvore.Arvore>
    {
        public class Arvore
        {
            public Arvore() 
            {
                IdNode = 0;
                DescricaoNode = string.Empty;
                AbaixoPai = 0;
                Profundidade = 0;
            }

            public int IdNode { get; set; }
            public string DescricaoNode { get; set; }
            public int AbaixoPai { get; set; }
            public int Profundidade { get; set; }
        }
    }
}
