using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidaCartaoTest.Bandeiras
{
    public class Master: CartaoBase
    {        
        private const int comprimento = 16;
        private string[] comecaCom = new string[] { "51", "55" };

        public Master() : base("Master")
        {

        }

        protected override bool ValidaBandeira(string numero)
        {
            return numero.Length == comprimento && comecaCom.Any(x => numero.StartsWith(x));
        }
    }
}
