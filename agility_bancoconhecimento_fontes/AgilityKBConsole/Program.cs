using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgilityKB.DAO;

namespace AgilityKBConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Conexao c = new Conexao();
            c.AbrirConexao();
        }
    }
}
